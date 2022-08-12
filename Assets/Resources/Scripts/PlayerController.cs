using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity;
    public float speed;
    public float boostTimer, slowTimer;
    public bool boosting, slowing;
    public bool collider = false;

    //shooting
    public Transform firePosition;
    public GameObject projectile;
    private bool canShoot = true;
    private float cooldownTimeShotting = 0.5f;
    GameObject obj;

    void Start()
    {
        speed = 10;
        velocity = 1;
        boostTimer = 0;
        slowTimer = 0;
        boosting = false;
        slowing = false;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, velocity * 300));
        }

        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 3)
            {
                speed = 10;
                boostTimer = 0;
                boosting = false;
            }
        }

        if (slowing)
        {
            slowTimer += Time.deltaTime;
            if (slowTimer >= 3)
            {
                speed = 10;
                boostTimer = 0;
                boosting = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (canShoot)
            {
                StartCoroutine(shoot());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collider")
        {
            collider = true;
        }
        if (collision.tag == "LightWareship")
        {
            speed = 0;
            Debug.Log("Player Die");
        }
        if (collision.tag == "BuffSpeed")
        {
            boosting = true;
            speed = 15;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "SlowSpeed")
        {
            boosting = true;
            speed = 8;
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator shoot()
    {
        shootLogic();
        canShoot = false;
        //wait for some time
        yield return new WaitForSeconds(cooldownTimeShotting);
        canShoot = true;
    }

    void shootLogic()
    {
        obj = Instantiate(projectile, firePosition.position, firePosition.rotation);
        if (transform.localScale.x == -0.2f)
        {
            obj.transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }
        else
        {
            obj.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}

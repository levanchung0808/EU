using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   public float Velocity = 1f;
    public float speed = 10f;
    public bool collider = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
       transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Velocity * 100));
        }      
        if(collider)
        {
            speed = 0;
            collider = false;
        }
        else
        {
            speed = 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Collider")
        {
            collider = true;
        }
        if (collision.tag == "LightWareship")
        {
            speed = 0;
            Debug.Log("Player Die");
        }
    }
}

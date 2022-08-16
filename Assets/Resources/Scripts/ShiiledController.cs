using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiiledController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator ani;
    public GameObject impactEffect;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            DestroyShilde();
        }
    }
        public void Shilde()
    {
        ani.Play("shiled");
    }
    public void DestroyShilde()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider")
        {
            ani.Play("Destroyshiled");
            Instantiate(impactEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            AudioManager.SetAudio("breakblock");
        }
    }
}

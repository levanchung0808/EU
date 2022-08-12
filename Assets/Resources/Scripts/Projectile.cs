using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject impactEffect;

    private Rigidbody2D rg;

    // Start is called before the first frame update
    void Start()
    {
        projectileSpeed = 20;
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = transform.right * projectileSpeed;
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider")
        {
            Destroy(gameObject);
            Instantiate(impactEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}

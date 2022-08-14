using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject impactEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x-0.5f,transform.position.y- 1f), 5*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "isGround")
        {
            Instantiate(impactEffect, transform.position, collision.transform.rotation);
            Destroy(gameObject);
        }
    }
}

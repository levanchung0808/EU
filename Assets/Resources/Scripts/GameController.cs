using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject warShip;
    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*warShip.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,speed));
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, speed));*/
        warShip.transform.Translate(Vector3.right * speed * Time.deltaTime);
       
    }
}

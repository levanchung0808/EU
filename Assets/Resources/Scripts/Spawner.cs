using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ground_1;
    public GameObject Ground_2;
    public GameObject Ground_3;
    System.Random r = new System.Random();
    public GameObject objPlayer;
    public bool isSpawn = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objPlayer.transform.position.x+10, 0, -10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "creatground")
        {
            Debug.Log("có chạm");
            spawnGround();
            Destroy(collision.gameObject);
        }
    }
    private void spawnGround()
    {
        int x = r.Next(1, 3);
        switch (x)
        {
            case 1:
                Debug.Log(1);
                Instantiate(Ground_1, new Vector3(transform.position.x, 8, transform.position.z), transform.rotation);
                break;
            case 2:
                Debug.Log(2);
                Instantiate(Ground_2, new Vector3(transform.position.x, 8, transform.position.z), transform.rotation);
                break;
        }

    }
}

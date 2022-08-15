using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ground_1;
    public GameObject Ground_2;
    public GameObject Ground_3;
    public GameObject Ground_4;
    public GameObject Ground_5;
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
        int x = r.Next(1, 6);
        switch (x)
        {
            case 1:
                Instantiate(Ground_1, new Vector3(transform.localPosition.x, 8, transform.localPosition.z), transform.rotation);
                break;
            case 2:
                Instantiate(Ground_2, new Vector3(transform.localPosition.x, 8, transform.localPosition.z), transform.rotation);
                break;
            case 3:
                Instantiate(Ground_3, new Vector3(transform.localPosition.x, 8, transform.localPosition.z), transform.rotation);
                break;
            case 4:
                Instantiate(Ground_4, new Vector3(transform.localPosition.x, 8, transform.localPosition.z), transform.rotation);
                break;
            case 5:
                Instantiate(Ground_5, new Vector3(transform.localPosition.x, 8, transform.localPosition.z), transform.rotation);
                break;
        }

    }
}

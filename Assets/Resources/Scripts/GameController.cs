using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject warShip;
    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        warShip.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if ((player.transform.localPosition.x - warShip.transform.position.x) >= 20)
        {
            speed = 15;
        }
        if ((player.transform.localPosition.x - warShip.transform.position.x) <= 12)
        {
            speed = 10;
        }
    }
}

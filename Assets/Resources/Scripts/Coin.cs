using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public int count = 0;
    bool iStop = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!iStop)
        {
            tuHuy();
        }
    }
    public void tuHuy()
    {
        count++;
       // transform.Rotate(1f, 1f, 0);
        transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
        if (count == 180)
        {
            iStop = true;
        }
    }
}

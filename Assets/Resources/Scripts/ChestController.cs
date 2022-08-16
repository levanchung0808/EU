using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator ani;
    public static bool isClick;
    void Start()
    {
        isClick = false;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isClick)
        {
            ani.Play("Chest");
            isClick = false;
        }
    }
}

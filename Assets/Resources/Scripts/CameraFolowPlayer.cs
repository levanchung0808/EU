using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowPlayer : MonoBehaviour
{
    public GameObject objPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objPlayer.transform.position.x , transform.position.y, -10);
    }


}

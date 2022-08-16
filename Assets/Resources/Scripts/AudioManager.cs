using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource audio;
    public AudioClip clickSound;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetAudio(string _nameAudio)
    {
        if (_nameAudio != null)
        {
            audio.PlayOneShot(Resources.Load<AudioClip>("Audio/" + _nameAudio));
        }
    }
}

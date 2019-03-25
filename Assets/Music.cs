using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    public bool play;
    public bool ignore1 = false;
    public bool ignore2 = false;
    public bool ignore3 = false;

    int once = 1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        play = true;
    }

    void Update()
    {
        if ((play == true) && (once == 1) && !ignore1 && !ignore2 && !ignore3)
        {
            audioSource.Play(0);
            once = 0;
        }
        if (play == false)
        {
            audioSource.Stop();
            once = 1;
        }
    }
}

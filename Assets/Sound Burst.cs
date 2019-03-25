using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBurst : MonoBehaviour
{
   
    public AudioClip crashHard;


    private AudioSource source;


    void Awake()
    {

        source = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision coll)
    {
        //source.pitch = Random.Range(lowPitchRange, highPitchRange);
        //float hitVol = coll.relativeVelocity.magnitude * velToVol;
        //if (coll.relativeVelocity.magnitude < velocityClipSplit)
        //    source.PlayOneShot(crashSoft, hitVol);
        //else
            source.PlayOneShot(crashHard, 100);
    }

}


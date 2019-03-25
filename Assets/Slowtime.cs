using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowtime : MonoBehaviour
{
    AudioSource audioData;
    public bool playslow;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject.Find("Floor").GetComponent<Music>().play = false;
            GameObject.Find("Floor").GetComponent<Music>().ignore2 = true;
            GameObject.Find("Invincibility").GetComponent<Invincibility>().playinv = false;
            GameObject.Find("Timer").GetComponent<Timer>().playtimer = false;
            audioData.Play(0);
            GameObject.Find("Player").GetComponent<Player>().slow = true;
            foreach (var x in GameObject.FindObjectsOfType<Spiky>())
            {
                x.spikyslow = true;
            }
            transform.position = new Vector3(1000, 1000, 1000);
            StartCoroutine(waiter2());
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {      
        yield return new WaitForSeconds(21f);
        GameObject.Find("Player").GetComponent<Player>().slow = false;
        foreach (var x in GameObject.FindObjectsOfType<Spiky>())
        {
            x.spikyslow = false;
        }
        GameObject.Find("Floor").GetComponent<Music>().play = true;
        GameObject.Find("Floor").GetComponent<Music>().ignore2 = false;
        yield return null;
    }

    IEnumerator waiter2()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Invincibility").GetComponent<Invincibility>().playinv = true;
        GameObject.Find("Timer").GetComponent<Timer>().playtimer = true;
       
        yield return null;
    }

    void Start()
    {
        playslow = true;
        audioData = GetComponent<AudioSource>();
        transform.position = new Vector3(1000, 1000, 1000);
    }

    void Update()
    {
        if (!playslow)
        {
            audioData.Stop();
        }
    }
}

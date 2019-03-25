using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    AudioSource audioData;
    public bool playtimer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject.Find("Floor").GetComponent<Music>().play = false;
            GameObject.Find("Floor").GetComponent<Music>().ignore1 = true;
            GameObject.Find("Invincibility").GetComponent<Invincibility>().playinv = false;
            GameObject.Find("Slowtime").GetComponent<Slowtime>().playslow = false;
            audioData.Play(0);
            foreach (var x in GameObject.FindObjectsOfType<ColouredSphere>())
            {
                x.timer = true;
            }
            transform.position = new Vector3(1000, 1000, 1000);
            StartCoroutine(waiter2());
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(40f);
        foreach (var x in GameObject.FindObjectsOfType<ColouredSphere>())
        {
            x.timer = false;
        }
        GameObject.Find("Floor").GetComponent<Music>().play = true;
        GameObject.Find("Floor").GetComponent<Music>().ignore1 = false;
        yield return null;
    }

    IEnumerator waiter2()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Invincibility").GetComponent<Invincibility>().playinv = true;
        GameObject.Find("Slowtime").GetComponent<Slowtime>().playslow = true;
        yield return null;
    }

    void Start()
    {
        playtimer = true;
        audioData = GetComponent<AudioSource>();
        transform.position = new Vector3(1000, 1000, 1000);
    }

    void Update()
    {
        if (!playtimer)
        {
            audioData.Stop();
        }
    }
}

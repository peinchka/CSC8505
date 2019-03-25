using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    AudioSource audioData;

    public bool playinv;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject.Find("Floor").GetComponent<Music>().play = false;
            GameObject.Find("Floor").GetComponent<Music>().ignore3 = true;
            GameObject.Find("Timer").GetComponent<Timer>().playtimer = false;
            GameObject.Find("Slowtime").GetComponent<Slowtime>().playslow = false;
            audioData.Play(0);
            GameObject.Find("Player").GetComponent<Player>().invincible = true;
            foreach (var x in GameObject.FindObjectsOfType<ColouredSphere>())
            {
                x.invinc = true;
            }
            transform.position = new Vector3(1000, 1000, 1000);
            StartCoroutine(waiter2());
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {      
        yield return new WaitForSeconds(50f);
        GameObject.Find("Player").GetComponent<Player>().invincible = false;
        foreach (var x in GameObject.FindObjectsOfType<ColouredSphere>())
        {
            x.invinc = false;
        }
        GameObject.Find("Floor").GetComponent<Music>().play = true;
        GameObject.Find("Floor").GetComponent<Music>().ignore3 = false;
        yield return null;
    }

    IEnumerator waiter2()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Timer").GetComponent<Timer>().playtimer = true;
        GameObject.Find("Slowtime").GetComponent<Slowtime>().playslow = true;
        yield return null;
    }

    void Start()
    {
        playinv = true;
        audioData = GetComponent<AudioSource>();
        transform.position = new Vector3(1000, 1000, 1000);
    }

    void Update()
    {

        if (!playinv)
        {
            audioData.Stop();
        }
    }
}

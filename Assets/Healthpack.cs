using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
    [SerializeField] AudioClip collect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collect, transform.localPosition, 1);
            GameObject.Find("Player").GetComponent<Player>().health += 50;
            transform.position = new Vector3(1000, 1000, 1000);
        }
    }

    private void Start()
    {
        transform.position = new Vector3(1000, 1000, 1000);
    }

    void Update()
    {
       
    }
}

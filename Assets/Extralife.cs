using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extralife : MonoBehaviour
{
    [SerializeField] AudioClip collectlife;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectlife, transform.localPosition, 1);
            GameObject.Find("Player").GetComponent<Player>().lives += 1;
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

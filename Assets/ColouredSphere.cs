using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

//[RequireComponent(typeof(Light))]

public class ColouredSphere : MonoBehaviour
{
    private Rigidbody rb;
    float randomx;
    float randomz;
    public bool invinc = false;
    public bool timer = false;

    [SerializeField]
    AudioClip impact;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Spiky"))
        {
            AudioSource.PlayClipAtPoint(impact, transform.position, 100);
            transform.localScale *= 0.707f;
            if (transform.localScale.x < 1F)
            {
                Destroy(gameObject);
                if ((collision.collider.GetComponent<Spiky>().target != null) || (collision.collider.transform.position.y > 1.5))
                {
                    GameObject.Find("Player").GetComponent<Player>().score += 100;
                }
            }
            else
            {
                Vector3 vec;
                vec.x = Random.Range(0.0f, 1.0f);
                vec.z = Random.Range(0.0f, 1.0f);
                vec.y = 0.0f;
                vec.Normalize();

                GameObject instance = (GameObject)Instantiate(gameObject, transform.position, Quaternion.identity);
                rb = instance.GetComponent<Rigidbody>();
                rb.AddTorque(transform.right * 10);
                rb.AddForce((0.5F * vec + 1.5F * Vector3.up) * 5);

                transform.position = transform.position - 0.75F * transform.localScale.x * vec;
                rb = gameObject.GetComponent<Rigidbody>();
                rb.AddTorque(-transform.right * 10);
                rb.AddForce((-0.5F * vec + 1.5F * Vector3.up) * 5);

                if ((collision.collider.GetComponent<Spiky>().target != null)|| (collision.collider.transform.position.y > 1.5))
                {
                    if ((transform.localScale.x > 7) && (transform.localScale.x < 8))
                    {               
                        GameObject.Find("Player").GetComponent<Player>().score += 10;
                    }
                    if ((transform.localScale.x > 4) && (transform.localScale.x < 6))
                    {                  
                        GameObject.Find("Player").GetComponent<Player>().score += 20;
                    }
                    if ((transform.localScale.x > 3) && (transform.localScale.x < 4))
                    {                   
                        GameObject.Find("Player").GetComponent<Player>().score += 30;
                    }
                    if ((transform.localScale.x > 2) && (transform.localScale.x < 3))
                    {                  
                        GameObject.Find("Player").GetComponent<Player>().score += 40;
                    }
                    if ((transform.localScale.x > 1.5) && (transform.localScale.x < 2))
                    {                   
                        GameObject.Find("Player").GetComponent<Player>().score += 60;
                    }
                    if ((transform.localScale.x > 1) && (transform.localScale.x < 1.5))
                    {
                        GameObject.Find("Player").GetComponent<Player>().score += 80;
                    }
                }
            }
        }
        if (collision.collider.CompareTag("Player"))
        {
            if (invinc)
            {
                AudioSource.PlayClipAtPoint(impact, transform.position, 100);
                transform.localScale *= 0.707f;
                if (transform.localScale.x < 1F)
                {
                    Destroy(gameObject);
                    GameObject.Find("Player").GetComponent<Player>().score += 50;
                }
                else
                {
                    Vector3 vec;
                    vec.x = Random.Range(0.0f, 1.0f);
                    vec.z = Random.Range(0.0f, 1.0f);
                    vec.y = 0.0f;
                    vec.Normalize();

                    GameObject instance = (GameObject)Instantiate(gameObject, transform.position, Quaternion.identity);
                    rb = instance.GetComponent<Rigidbody>();
                    rb.AddTorque(transform.right * 10);
                    rb.AddForce((0.5F * vec + 1.5F * Vector3.up) * 5);

                    transform.position = transform.position - 0.75F * transform.localScale.x * vec;
                    rb = gameObject.GetComponent<Rigidbody>();
                    rb.AddTorque(-transform.right * 10);
                    rb.AddForce((-0.5F * vec + 1.5F * Vector3.up) * 5);

                    if ((transform.localScale.x > 7) && (transform.localScale.x < 8))
                    {                      
                        GameObject.Find("Player").GetComponent<Player>().score += 5;
                    }
                    if ((transform.localScale.x > 4) && (transform.localScale.x < 6))
                    {                      
                        GameObject.Find("Player").GetComponent<Player>().score += 10;
                    }
                    if ((transform.localScale.x > 3) && (transform.localScale.x < 4))
                    {                       
                        GameObject.Find("Player").GetComponent<Player>().score += 15;
                    }
                    if ((transform.localScale.x > 2) && (transform.localScale.x < 3))
                    {                     
                        GameObject.Find("Player").GetComponent<Player>().score += 20;
                    }
                    if ((transform.localScale.x > 1.5) && (transform.localScale.x < 2))
                    {                       
                        GameObject.Find("Player").GetComponent<Player>().score += 30;
                    }
                    if ((transform.localScale.x > 1) && (transform.localScale.x < 1.5))
                    {                       
                        GameObject.Find("Player").GetComponent<Player>().score += 40;
                    }
                }
            }
            else
            {
                if (this.CompareTag("Red"))
                {
                    AudioSource.PlayClipAtPoint(impact, transform.position, 1);
                    GameObject.Find("Player").GetComponent<Player>().lives--;
                    GameObject.Find("Player").GetComponent<Player>().health = 100;
                }
                else
                {
                    if (transform.localScale.x == 10)
                    {
                        GameObject.Find("Player").GetComponent<Player>().health -= 50;
                    }
                    if ((transform.localScale.x > 7) && (transform.localScale.x < 8))
                    {
                        GameObject.Find("Player").GetComponent<Player>().health -= 40;
                    }
                    if ((transform.localScale.x > 4) && (transform.localScale.x < 6))
                    {
                        GameObject.Find("Player").GetComponent<Player>().health -= 30;
                    }
                    if ((transform.localScale.x > 3) && (transform.localScale.x < 4))
                    {
                        GameObject.Find("Player").GetComponent<Player>().health -= 25;
                    }
                    if ((transform.localScale.x > 2) && (transform.localScale.x < 3))
                    {
                        GameObject.Find("Player").GetComponent<Player>().health -= 20;
                    }
                    if ((transform.localScale.x > 1.5) && (transform.localScale.x < 2))
                    {
                        GameObject.Find("Player").GetComponent<Player>().health -= 10;
                    }
                    if ((transform.localScale.x > 1) && (transform.localScale.x < 1.5))
                    {
                        GameObject.Find("Player").GetComponent<Player>().health -= 5;
                    }
                }
            }
        }
    }

    void Start()
    {
       
    }

    void Update()
    {
        if (transform.position.y < 0.0f)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            foreach (var x in GameObject.FindObjectsOfType<ColouredSphere>())
            {
                x.invinc = true;
                x.timer = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            foreach (var x in GameObject.FindObjectsOfType<ColouredSphere>())
            {
                x.invinc = false;
                x.timer = false;
            }
        }

        if (timer == true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.localScale *= 0.707F;
            if (transform.localScale.x < 1F)
            {
                Destroy(gameObject);
            }
            else
            {
                Vector3 vec;
                vec.x = Random.Range(0.0f, 1.0f);
                vec.z = Random.Range(0.0f, 1.0f);
                vec.y = 0.0f;
                vec.Normalize();

                GameObject instance = (GameObject)Instantiate(gameObject, transform.position + 0.75F * transform.localScale.x * vec, transform.rotation);
                rb = instance.GetComponent<Rigidbody>();
                rb.AddTorque(transform.right * 10);
                rb.AddForce((0.5F * vec + 1.5F * Vector3.up) * 5);

                //gameObject.GetComponent<Light>().range *= 0.707F;
                //instance.GetComponent<Light>().range *= 0.707F;

                transform.position = transform.position - 0.75F * transform.localScale.x * vec;
                rb = gameObject.GetComponent<Rigidbody>();
                rb.AddTorque(-transform.right * 10);
                rb.AddForce((-0.5F * vec + 1.5F * Vector3.up) * 5);
            }
        }
    }
}
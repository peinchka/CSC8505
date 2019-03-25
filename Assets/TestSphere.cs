using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSphere : MonoBehaviour
{
    public Rigidbody rb;
    public float range;
    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.localScale *= 0.707F;
           
            //lt.range *= 0.707F;


            if (transform.localScale.x < 1F)
            {
                Destroy(gameObject);
            }
            else
            {
                GameObject instance = (GameObject)Instantiate(gameObject, transform.position + 0.75F * transform.localScale.x * Vector3.right, transform.rotation);
                rb = instance.GetComponent<Rigidbody>();
                rb.AddTorque(transform.right * 10);
                rb.AddForce((0.5F * Vector3.right +  1.5F * Vector3.up) * 5);
                GameObject instance1 = (GameObject)Instantiate(gameObject, transform.position + 0.75F * transform.localScale.x * Vector3.left, transform.rotation);
                rb = instance1.GetComponent<Rigidbody>();
                rb.AddTorque(-transform.right * 10);
                rb.AddForce((0.5F * Vector3.left + 1.5F * Vector3.up) * 5);
                Destroy(gameObject);
            } 
        }
    }
}

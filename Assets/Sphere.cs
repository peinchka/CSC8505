using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    GameObject target;
    public Rigidbody rb;
    float force = 10F;
    float torque = 20F;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Cyan");
        rb = target.GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.forward * torque);
        rb.AddForce((0.5F * Vector3.forward + 1.5F * Vector3.up) * force);

        target = GameObject.FindGameObjectWithTag("Yellow");
        rb = target.GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.right * torque);
        rb.AddForce((0.5F * Vector3.right + 1.5F * Vector3.up) * force);

        target = GameObject.FindGameObjectWithTag("Red");
        rb = target.GetComponent<Rigidbody>();
        rb.AddTorque(-Vector3.right * torque);
        rb.AddForce((0.5F * Vector3.left + 1.5F * Vector3.up) * force);

        target = GameObject.FindGameObjectWithTag("Green");
        rb = target.GetComponent<Rigidbody>();
        rb.AddTorque(-Vector3.forward * torque);
        rb.AddForce((0.5F * Vector3.back + 1.5F * Vector3.up) * force);

        target = GameObject.FindGameObjectWithTag("Blue");
        rb = target.GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.forward * torque);
        rb.AddForce((0.5F * Vector3.forward + 1.5F * Vector3.up) * force);

        target = GameObject.FindGameObjectWithTag("Orange");
        rb = target.GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.forward * torque);
        rb.AddForce((0.5F * Vector3.forward + 1.5F * Vector3.up) * force);

        target = GameObject.FindGameObjectWithTag("Uncoloured");
        rb = target.GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.forward * torque);
        rb.AddForce((0.5F * Vector3.forward + 1.5F * Vector3.up) * force);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

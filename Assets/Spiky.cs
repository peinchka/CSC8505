using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiky : MonoBehaviour
{
    public GameObject target = null;

    [SerializeField]
    private float minDistance = 5;
    [SerializeField]
    private float speed = 25;
    public bool spikyslow = false;

    private void Start()
    {

    }

    void Update()
    {
        if (spikyslow)
        {
            speed = 50;
        }
        else
        {
            speed = 25;
        }
        if (target != null && (transform.position - target.transform.position).magnitude > minDistance)
        {
            var direction = (target.transform.position - transform.position).normalized;
            var amount = direction * speed * Time.deltaTime;
            transform.position += amount;
        }
    }
}

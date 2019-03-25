using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{

    bool increase = false;

    public float range { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp = transform.position;
        temp.x = -20;
        temp.y = 10;
        temp.z = -20;
        transform.position = temp;     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        if (increase)
        {
            temp.x -= 10 * Time.deltaTime;
            Light light = gameObject.GetComponent<Light>();
            light.range = 150;
        }
        if (!increase)
        {
            temp.x += 10 * Time.deltaTime;
            gameObject.GetComponent<Light>().range = 50;
        }
        if (temp.x > 0) { increase = true; }
        if (temp.x < -20) { increase = false; }
        transform.position = temp;
    }
}

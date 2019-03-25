using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    float camspeed = 10;
    float speed = 100;
    GameObject target;
    GameObject cam;
    Vector3 offset;
    float initialOffset;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        target = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("ActualCamera");
        initialOffset = cam.transform.localPosition.z;
    }

    void Update()
    {
        offset = cam.transform.localPosition;
        offset.z -= 3 * Input.mouseScrollDelta.y;
        offset.z = Mathf.Clamp(offset.z, 10, 200);
        if (Input.GetMouseButton(2))
        {
            offset.z = initialOffset;
        }
        cam.transform.localPosition = offset;
        transform.position = target.transform.position;
        CheckInputs();
    }

    private void CheckInputs()
    {
        var temp = transform.localEulerAngles;
        temp.x -= speed * Time.deltaTime * Input.GetAxis("Mouse Y");
        if(temp.x > 180f) { temp.x -= 360.0f; }
        temp.x = Mathf.Clamp(temp.x, -80, 80);
        temp.y += speed * Time.deltaTime * Input.GetAxis("Mouse X");

        transform.localRotation = Quaternion.Euler(temp);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * camspeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * camspeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * camspeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * camspeed * Time.deltaTime;
        }
    }
}

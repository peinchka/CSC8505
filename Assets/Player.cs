using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//using System;

public class Player : MonoBehaviour
{
    private float speed = 20;
    private float jumpHeight = 7;
    [SerializeField]
    AudioClip jump;
    [SerializeField]
    AudioClip gameover;

    public int lives;
    public int health;
    public int score;
    public bool invincible;
    public bool slow = false;
    private Rigidbody rb;
    GameObject target;
    int volume;
    bool pause = false;
    bool HealthPU = true;
    bool SlowPU = true;
    bool InvPU = true;
    bool TimerPU = true;
    bool ExtralifePU = true;

    Stack<GameObject> spikyballs = new Stack<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Spiky"))
        {
            GameObject spiky = collision.gameObject;
            if (spiky.GetComponent<Spiky>().target == null)
            {
                spikyballs.Push(spiky);
                collision.collider.GetComponent<Spiky>().target = gameObject;
            }        
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 1.1f);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject.Find("Text1").GetComponent<Text>().text = "Lives = " + lives.ToString();
        GameObject.Find("Text2").GetComponent<Text>().text = "Health = " + health.ToString();
        invincible = false;
        lives = 5;
        health = 100;
        score = 0;     
    }

    void Update()
    {
        int t = 0;
        foreach (var x in GameObject.FindObjectsOfType<ColouredSphere>())
        {
            t++;
        }
        if (t == 0)
        {
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene(2);
        }
        GameObject.Find("SpikySpheres").GetComponent<Text>().text = spikyballs.Count.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            if (spikyballs.Count > 0)
            {
                spikyballs.Peek().GetComponent<Spiky>().target = null;
                Vector3 temp = transform.position;
                temp.y += 3;
                spikyballs.Peek().transform.position = temp;
                float force = 50.0f;
                if (slow)
                {
                    force = 100.0f;
                }
                spikyballs.Pop().GetComponent<Rigidbody>().AddForceAtPosition(-(GameObject.Find("CameraControl").transform.forward).normalized * force, transform.position);
            }      
        }

        if (Input.GetMouseButton(1))
        {
            if (spikyballs.Count > 0)
            {
                Vector3 direction = -((GameObject.Find("CameraControl").transform.forward)).normalized;
                int z = 0;
                foreach (GameObject spikyball in spikyballs)
                {
                    z += 2;
                    spikyball.GetComponent<Rigidbody>().AddForceAtPosition((transform.position + z * direction - spikyball.transform.position).normalized * 2, spikyball.transform.position);
                }
            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            foreach (GameObject obj in spikyballs)
            {
                obj.GetComponent<Spiky>().target = null;
            }
            spikyballs.Clear();   
        }

        GameObject.Find("Text5").GetComponent<Text>().text = "Score = " + score.ToString();
        if ((((score - score % 100) == 100)||((score - score % 100) == 5100)) && (HealthPU == true))
        {
            GameObject.Find("Healthpack").GetComponent<Healthpack>().transform.position = new Vector3(12, 1, 0);
            HealthPU = false;          
        }
        if ((((score - score % 100) == 300) || ((score - score % 100) == 5300)) && (SlowPU == true))
        {
            GameObject.Find("Slowtime").GetComponent<Slowtime>().transform.position = new Vector3(4, 1, 0);
            SlowPU = false;
        }
        if ((((score - score % 100) == 500) || ((score - score % 100) == 5500)) && (InvPU == true))
        {
            GameObject.Find("Invincibility").GetComponent<Invincibility>().transform.position = new Vector3(-4, 1, 0);
            InvPU = false;
        }
        if ((((score - score % 100) == 700) || ((score - score % 100) == 5700)) && (TimerPU == true))
        {
            GameObject.Find("Timer").GetComponent<Timer>().transform.position = new Vector3(-12, 1, 0);
            TimerPU = false;
        }
        if ((((score - score % 100) == 900) || ((score - score % 100) == 5900)) && (ExtralifePU == true))
        {
            GameObject.Find("1UP").GetComponent<Extralife>().transform.position = new Vector3(-20, 1, 0);
            ExtralifePU = false;          
        }
        if ((score - score % 100) == 5000)
        {
            HealthPU = true;
            SlowPU = true;
            InvPU = true;
            TimerPU = true;
            ExtralifePU = true;
        }
        if (pause)
        {
            GameObject.Find("Text4").GetComponent<Text>().text = "PRESS ENTER/RETURN TO UNPAUSE    PRESS SHIFT TO RETURN TO MAIN MENU    PRESS ESCAPE TO EXIT APPLICATION";
            Time.timeScale = 0.0f;
            Time.fixedDeltaTime = 0.016f * Time.timeScale;
            GameObject.Find("Image").GetComponent<Image>().enabled = true;
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
            GameObject.Find("Text3").GetComponent<Text>().text = "Framerate = Paused";
        }
        else
        {
            GameObject.Find("Text4").GetComponent<Text>().text = "";
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.016f * Time.timeScale;
            GameObject.Find("Image").GetComponent<Image>().enabled = false;
            if (slow)
            {
                Time.timeScale = 0.5f;
                Time.fixedDeltaTime = 0.016f * Time.timeScale;
                speed = 40;
                GameObject.Find("Text3").GetComponent<Text>().text = "Framerate = " + (0.5 / Time.deltaTime).ToString("N0");
            }
            else
            {
                speed = 20;
                GameObject.Find("Text3").GetComponent<Text>().text = "Framerate = " + (1 / Time.deltaTime).ToString("N0");
            }
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(2);
        }

        CheckInputs();
        if (invincible)
        {
            GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value, 1);
        }
        if (health <= 0)
        {
            lives--;
            health = 100;
        }
        if (health > 100)
        {
            health = 100;
        }
        if (lives <= 0)
        {
            health = 0;
            lives = 0;
            GameObject.Find("Text2").GetComponent<Text>().text = "Health = " + health.ToString();
            if (volume == 1)
            {
                AudioSource.PlayClipAtPoint(gameover, transform.position, 1);
                volume = 0;
            }
            Time.timeScale = 0.0f;
            GameObject.Find("Image").GetComponent<Image>().enabled = true;
            GameObject.Find("Text4").GetComponent<Text>().text = "You died! You did not do very well!\nYou MUST try harder! GAME OVER!\nPRESS SHIFT TO RETURN TO MAIN MENU";
            GameObject.Find("Text3").GetComponent<Text>().text = "Framerate = 0";
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                Time.timeScale = 1.0f;
                GameObject.Find("Image").GetComponent<Image>().enabled = false;
                SceneManager.LoadScene(0);
            }
        }
        GameObject.Find("Text1").GetComponent<Text>().text = "Lives = " + lives.ToString();
        GameObject.Find("Text2").GetComponent<Text>().text = "Health = " + health.ToString();
    }

    private void CheckInputs()
    {
        target = GameObject.FindGameObjectWithTag("Camera");
        var camtemp = target.transform.localEulerAngles;
        var rot = transform.localEulerAngles;
        rot.y = camtemp.y;
        transform.localRotation = Quaternion.Euler(rot);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            pause = !pause;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 temp = transform.position;
            temp += transform.right * speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 temp = transform.position;
            temp -= transform.right * speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 temp = transform.position;
            temp -= transform.forward * speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 temp = transform.position;
            temp += transform.forward * speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded() || invincible))
        {
            AudioSource.PlayClipAtPoint(jump, transform.position, 1);
            rb.velocity = new Vector3(0, 1, 0) * jumpHeight;
        }
    }
}

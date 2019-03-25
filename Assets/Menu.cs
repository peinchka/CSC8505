using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool begin;
    int once;
    [SerializeField]
    AudioClip start;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        begin = false;
    }

    IEnumerator waiter()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(0.7f);
              
        begin = false;
        
        SceneManager.LoadScene(1);
        yield return null;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            begin = true;
            once = 1;
            AudioSource.PlayClipAtPoint(start, transform.position, 100);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (begin == true)
        {         
            Vector3 temp = transform.position;
            temp -= transform.forward * 0.35f;
            transform.position = temp;
            if (once == 1)
            {
                StartCoroutine(waiter());
                
            }
            once++;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int finalscore;
    int bestscore;

    void Start()
    {
        bestscore = PlayerPrefs.GetInt("BestScore", 0);
        finalscore = PlayerPrefs.GetInt("Score", 0);
        if (finalscore > bestscore)
        {
            PlayerPrefs.SetInt("BestScore", finalscore);
            bestscore = finalscore;
        }
    }

    void Update()
    {
        GetComponent<TextMesh>().text = "Your score was: " + finalscore.ToString() + "\nBest is: " + bestscore;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;

    public int currScore;

    public TMP_Text scoreTextUI;
 
    void Start()
    {
        score = 0;
        currScore = score;
        scoreTextUI.text = currScore.ToString();
    }

   
    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        currScore = score;
        scoreTextUI.text = currScore.ToString();
    }
}

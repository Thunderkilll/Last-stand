using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Lives : MonoBehaviour
{
    public static int lives;

    public int currLives;

    public TMP_Text scoreTextUI;

    void Start()
    {

        lives = currLives;
        scoreTextUI.text = currLives.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateLives();
    }

    void UpdateLives()
    {
        if (lives >= 0)
        {
            currLives = lives;
            scoreTextUI.text = currLives.ToString();
        }
        
    }
}

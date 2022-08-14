using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreLives : MonoBehaviour
{
    public GameObject deathPanel;
    public GameObject gamePanel;

    public void ChangeScore()
    {
        Score.score++;
    }

    public void ChangeLives()
    {
        if (Lives.lives > 0)
        {
            Lives.lives--;
        }
     
    }

    void Start()
    {
        deathPanel.SetActive(false);
    }
    void Update()
    {
        EndGame();
    }

    public void EndGame()
    {
        if (Lives.lives == 0)
        {
            gamePanel.SetActive(false);
            deathPanel.SetActive(true);
            
            Time.timeScale = 0;
           
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        //get cuurent active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void StartGame(string name)
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        LevelManager.instance.LoadSceneMode(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region singleton
    public static LevelManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Variables

    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private GameObject lights;
    [SerializeField] private Image progressBar;
    private float _target;
    #endregion


    void Start()
    {
        loaderCanvas.SetActive(false);
        lights.SetActive(false);
        progressBar.fillAmount = 0;
    }

    public async void LoadSceneMode(string sceneName)
    {
        _target = 0;
        loaderCanvas.SetActive(false);
        lights.SetActive(false);
        progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        //activate loader scene
        loaderCanvas.SetActive(true);
        //loading logic
        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        } while (scene.progress < .9f);

        progressBar.fillAmount = 1;

        lights.SetActive(true);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;

        //end loader scene
        loaderCanvas.SetActive(false);
        lights.SetActive(false);
    }

    void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, _target, .5f * Time.deltaTime);
    }
}

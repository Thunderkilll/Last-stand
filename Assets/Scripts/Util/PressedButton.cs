using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedButton : MonoBehaviour
{

    public GameObject mainMenuPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            gameObject.SetActive(false);
            mainMenuPanel.SetActive(true);

        }
    }
}

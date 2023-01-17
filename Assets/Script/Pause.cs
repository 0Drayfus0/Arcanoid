using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject PausePanel;
    public bool pauseActive;

    public GameObject pausePanel;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pauseActive)
            {
                Time.timeScale = 1f;
                pauseActive = false;
                
            }
            else
            {
                Time.timeScale = 0f;
                pauseActive = true;
                pausePanel.SetActive(true);
                    
                
            }

            pausePanel.SetActive(pauseActive);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject PausePanel;
    public bool pauseActive;

    public GameObject pausePanel;

    public AudioClip sndPauseActive;
    public AudioClip sndPauseDeactivate;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pauseActive)
            {
                Time.timeScale = 1f;
                pauseActive = false;
                //audioManager.PlaySound(sndPauseActive);
            }
            else
            {
                Time.timeScale = 0f;
                pauseActive = true;
                pausePanel.SetActive(true);
                //audioManager.PlaySound(sndPauseDeactivate);
                    
                
            }

            pausePanel.SetActive(pauseActive);
        }
    }
}

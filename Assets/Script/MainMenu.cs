using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject menuPanel;
    public bool menuActive;
    public Text bestScoreText;


    private void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestRecord");
        bestScoreText.text = "Best RECORD: " + bestScore;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (menuActive)
            {
                Time.timeScale = 1f;
                menuActive = false;
                //audioManager.PlaySound(sndPauseActive);
            }
            else
            {
                Time.timeScale = 0f;
                menuActive = true;
                menuPanel.SetActive(true);
                //audioManager.PlaySound(sndPauseDeactivate);


            }

            menuPanel.SetActive(menuActive);
        }
    }
}

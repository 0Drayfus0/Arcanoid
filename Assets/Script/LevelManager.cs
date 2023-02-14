using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]int blocksCount;
    int indexScene;

    ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        indexScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void CreateBlock()
    {
        blocksCount++;   
    }
    public void BlockDestroyed()
    {
        blocksCount--;
        if(blocksCount <= 0)
        {
           
            SceneManager.LoadScene(indexScene + 1);
            scoreCounter.SaceBestScore();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(indexScene);
    }

}

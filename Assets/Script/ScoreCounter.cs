using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour
{
    int score;
    public Text ScoreText;

    private void Awake()
    {
        ScoreCounter[] scoreCounters = FindObjectsOfType<ScoreCounter>();
        for(int i = 0; i < scoreCounters.Length; i++)
        {
            if(scoreCounters[i] != this)
            {
                Destroy(gameObject);
            }

        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        ScoreText.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersLife : MonoBehaviour
{
    public Text LifeText;

    [SerializeField] int lifes;
    int indexLifes;

    LevelManager levelManager;
    Ball ball;
    ScoreCounter scoreCounter;

    private void Start()
    {

        indexLifes = lifes;
        levelManager = FindObjectOfType<LevelManager>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
        ball = FindObjectOfType<Ball>();
    }
    public void LoseLife()

    {
        lifes--;
        LifeText.text = "Lifes: " + lifes;


        ball.RestartBall();

        if (lifes <= 0)
        {
            scoreCounter.ZeroScore();
            lifes = indexLifes;
            levelManager.RestartGame();
        }

    }
    
}


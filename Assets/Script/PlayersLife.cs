using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersLife : MonoBehaviour
{
    public Text LifeText;

    public List<GameObject> lifesPng;
    
    int indexLifes;
    [SerializeField] int lifes;

    LevelManager levelManager;
    Ball ball;
    ScoreCounter scoreCounter;

    private void Start()
    {

        indexLifes = lifes;
        levelManager = FindObjectOfType<LevelManager>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
        ball = FindObjectOfType<Ball>();

        LifesTextUI();
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
        LifesTextUI();
    }
    private void LifesTextUI()
    {
        for (int index = 0; index < lifesPng.Count; index++)
        {
            if(index < lifes)
            {
                lifesPng[index].SetActive(true);
            }
            else
            {
                lifesPng[index].SetActive(false);
            }
        }
    }
}


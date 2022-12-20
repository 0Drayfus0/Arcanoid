using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int llives = 2;
    public int points;
    ScoreCounter scoreCounter;
    LevelManager levelManager;


    private void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        levelManager = FindObjectOfType<LevelManager>();

        levelManager.CreateBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        llives--;
        if(llives <= 0)
        {
            scoreCounter.AddScore(points);
            levelManager.BlockDestroyed();
            Destroy(gameObject);

        }
    }

 
}

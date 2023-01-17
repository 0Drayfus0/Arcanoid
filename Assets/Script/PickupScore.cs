using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScore : MonoBehaviour
{
    public int points;


    public void ApplyEffect()
    {
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreCounter.AddScore(points);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
            
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtomWall : MonoBehaviour
{
    PlayersLife playerLife;

    private void Start()
    {
        playerLife = FindObjectOfType<PlayersLife>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Ball"))
        {
            playerLife.LoseLife();
        }
        else
        {
            Destroy(collision.gameObject); 
        }
        
    }
}

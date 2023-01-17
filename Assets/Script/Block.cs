using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int llives = 2;
    public int points;
    public bool invisible;


    public GameObject PickupPrefab;
    SpriteRenderer spriteRenderer;

    ScoreCounter scoreCounter;
    LevelManager levelManager;


    private void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        levelManager = FindObjectOfType<LevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        levelManager.CreateBlock();

        if (invisible)
        {
            spriteRenderer.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invisible)
        {
            spriteRenderer.enabled = true;
            invisible = false;
            return;
        }


        llives--;
        if(llives <= 0)
        {
            BlockDestroy();
        }
    }
    private void BlockDestroy()
    {
        scoreCounter.AddScore(points);
        levelManager.BlockDestroyed();
        Instantiate(PickupPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
 
}

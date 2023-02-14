using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int lives;
    public int points;
    public bool invisible;

    [Header("Prefabs")]
    public GameObject PickupPrefab;
    public GameObject particlePrefab;

    [Header("explosive")]
    public bool explosive;
    public float explosiveRadius;

    [Header("Sound")]
    public AudioClip sndBlockDestroy;

    SpriteRenderer spriteRenderer;

    ScoreCounter scoreCounter;
    LevelManager levelManager;
    AudioManager audioManager;

    private void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioManager>();

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
        
        lives--;
        if(lives <= 0)
        {
            BlockDestroy();
        }
    }
    public void BlockDestroy()
    {
        scoreCounter.AddScore(points);
        levelManager.BlockDestroyed();

        //audioManager.PlaySound(sndBlockDestroy);
      
        Destroy(gameObject);

        if (explosive)
        {
            Explode();
        }
    }
    public void Explode()
    {
        int layerMask = LayerMask.GetMask("Block");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosiveRadius, layerMask);

        foreach (Collider2D col in colliders)
        {
            print(col.name);
            Block block = col.GetComponent<Block>();
            if(block == null)
            {
                Destroy(col.gameObject);
            }
            else
            {
                block.BlockDestroy();
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosiveRadius);
    }
   
}

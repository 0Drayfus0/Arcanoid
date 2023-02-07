using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickExplosive : MonoBehaviour
{
    public void ApllyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            ball.isExplosive();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            ApllyEffect();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed;

    bool isStarted;

    float randomX;


    public Pad pad;
    float yBallPosition;

    private void Start()
    {
        yBallPosition = transform.position.y;
    }

    private void Update()
    {
        if (isStarted)
        {

        }
        else
        {
            
            Vector3 ballNewPosition = new Vector3(pad.transform.position.x, yBallPosition, 0);
            transform.position = ballNewPosition;

            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }
        print(rb.velocity.magnitude);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, rb.velocity); 
    }
    private void StartBall()
    {
        randomX = Random.Range(-5f, 5f);
        Vector2 direction = new Vector2(randomX, 1);
        Vector2 force = direction.normalized * speed;
        //rb.AddForce(force);
        rb.velocity = force;
        isStarted = true;
    }
}

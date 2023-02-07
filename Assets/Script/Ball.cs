using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Pad pad;

    public float speed;
    public float explosiveRadius;

    AudioSource audioSource;
    public AudioClip chidoriEffect;
    public GameObject explosiveEffect;

    float speedKoef;
    float yBallPosition;
    float xDelta;
    float randomX;

    bool isStarted;
    bool explosive;
    bool isMagnetActive;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        yBallPosition = transform.position.y;
        xDelta = transform.position.x - pad.transform.position.x;
    }
    public void Duplicate()
    {

        Ball originalBall = this;
        Ball newBall = Instantiate(originalBall);
        newBall.speed = speed;
        if (isMagnetActive)
        {
            newBall.isMagnetActive = true;
        }
    }
    public void Magnet()
    {
        isMagnetActive = true;

    }
    public void MultiplySpeed(float speedKoef)
    {
        speed *= speedKoef;
        rb.velocity = rb.velocity.normalized * speed;

    }
    public void isExplosive()
    {
        explosive = true;
        explosiveEffect.SetActive(true);
        audioSource.PlayOneShot(chidoriEffect);
    }
    public void RestartBall()
    {
        isStarted = false;
        rb.velocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        if(isMagnetActive && collision.gameObject.CompareTag("Pad"))
        {
            Start();
            RestartBall();

        }

        if (explosive && collision.gameObject.CompareTag("Block"))
        {
            int layerMask = LayerMask.GetMask("Block");
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosiveRadius, layerMask);
            foreach (Collider2D col in colliders)
            {
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

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, explosiveRadius);
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

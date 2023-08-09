using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private bool canMove;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            rb.MovePosition(rb.position + Vector2.down * speed * Time.fixedDeltaTime);
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("WallBottom"))
        {
            Destroy(gameObject);
        }
    }

    public void OnGamePaused()
    {
        canMove = false;
    }

    public void OnGameResumed()
    {
        canMove = true;
    }
}

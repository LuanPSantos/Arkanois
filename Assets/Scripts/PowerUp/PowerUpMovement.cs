using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private GameEvent powerUpDestroyed;

    private bool canMove;
    
    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        if(canMove)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        } 
        
        if(transform.position.y < -5)
        {
            powerUpDestroyed.Raise();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            powerUpDestroyed.Raise();
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

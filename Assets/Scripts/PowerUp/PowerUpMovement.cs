using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

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

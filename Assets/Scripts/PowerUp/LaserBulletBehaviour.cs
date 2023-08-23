using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserBulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxDistanceY;
    private bool canMove;

    void Awake()
    {
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }

        if(transform.position.y > maxDistanceY)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
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

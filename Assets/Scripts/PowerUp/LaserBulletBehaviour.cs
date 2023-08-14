using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserBulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private int timeToLive = 1;
    private bool canMove;

    void Awake()
    {
        canMove = true;
    }

    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
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

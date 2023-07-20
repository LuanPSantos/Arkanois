using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserBulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private int timeToLive = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.up * Time.fixedDeltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(gameObject);
        }
    }
}

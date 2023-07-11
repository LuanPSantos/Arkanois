using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : MonoBehaviour
{
    public float speed;
    public UnityEvent OnOutOfMap;
    public Vector2 startPosition; //TODO Move to another class

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    public void OnStateChange(GameplayManager.State state) {
        switch(state) {
            case GameplayManager.State.WAITING_GAMEPLAY:
                rb.velocity = Vector2.zero;
                transform.position = startPosition;
                break;
            case GameplayManager.State.IN_GAME:
                rb.velocity = new Vector2(1, 1) * speed;
                break;
            default:
                rb.velocity = Vector2.zero;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(x, 1).normalized;
            float speed = rb.velocity.magnitude;
            rb.velocity = direction * speed;
        }
        if (collision.gameObject.CompareTag("WallBottom"))
        {
            OnOutOfMap?.Invoke();
        }

        reflectFor("Wall", collision, collision.contacts[0].normal.normalized);
        reflectFor("Brick", collision, collision.contacts[0].normal.normalized);
    }

    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    private void reflectFor(string tag, Collision2D collision, Vector2 normal)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            Vector2 direction = Vector2.Reflect(rb.velocity.normalized, normal);
            rb.velocity = direction * rb.velocity.magnitude;
        }
    }
}

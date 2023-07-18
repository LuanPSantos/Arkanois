using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : MonoBehaviour
{
    public float speed;
    public GameEvent BallOutOfMap;
    public Vector2 startPosition; //TODO Move to another class

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool canMove;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        canMove = false;
        movement = Vector2.zero;
        transform.position = startPosition;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            OnHitPaddle(collision);
        }
        if (collision.gameObject.CompareTag("WallBottom"))
        {
            BallOutOfMap.Raise();
        }

        ReflectFor("Wall", collision, collision.contacts[0].normal);
        ReflectFor("Brick", collision, collision.contacts[0].normal);
    }

    public void OnGameStarted()
    {
        RandomMovement();
        Move();
    }

    public void OnGameEnded()
    {
        movement = Vector2.zero;
    }

    public void OnGameLost()
    {
        movement = Vector2.zero;
    }

    public void Move()
    {
        canMove = true;
    }

    public void Stop()
    {
        canMove = false;
    }

    private void OnHitPaddle(Collision2D collision)
    {
        var x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
        var up = 1;
        movement = new Vector2(x, up).normalized;
    }

    private float HitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    private void ReflectFor(string tag, Collision2D collision, Vector2 normal)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            movement = Vector2.Reflect(movement, normal).normalized;
        }
    }

    private void RandomMovement()
    {
        var x = Random.Range(-0.8f, 0.8f);
        var up = 1;
        movement = new Vector2(x, up).normalized;
    }
}

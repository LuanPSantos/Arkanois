using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : MonoBehaviour
{
    public float speed;
    public Vector2 movement
    {
        private set;
        get;
    }
    public Vector2 startPosition
    {
        private set;
        get;
    }

    [SerializeField]
    private GameEvent BallOutOfBounderies;
    
    private Rigidbody2D rb;
    private bool canMove;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
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
            BallOutOfBounderies.Raise();
        }
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Brick"))
        {
            Reflect(collision.contacts[0].normal);
        }
    }

    public void OnGameStarted()
    {
        ResetPosition();
        RandomMovement();
    }

    public void OnGameEnded()
    {
        movement = Vector2.zero;
    }

    public void OnGameLost()
    {
        movement = Vector2.zero;
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
    }

    public void Move(Vector3 movement)
    {
        this.movement = movement;
        Move();
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
        movement = ReflectOnPaddle(transform.position, collision.transform.position, collision.collider.bounds.size.x);
    }

    private Vector2 ReflectOnPaddle(Vector2 ballPosition, Vector2 paddlePosition, float paddleWidth)
    {
        var x = (ballPosition.x - paddlePosition.x) / paddleWidth;
        var up = 1;
        return new Vector2(x, up).normalized;
    }

    private void Reflect(Vector2 normal)
    {
        movement = Vector2.Reflect(movement, normal).normalized;
    }

    private void RandomMovement()
    {
        var x = Random.Range(-0.8f, 0.8f);
        var up = 1;
        movement = new Vector2(x, up).normalized;

        Move();
    }
}

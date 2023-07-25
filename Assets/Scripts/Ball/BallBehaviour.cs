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
    [SerializeField]
    private float fieldMinimumX = -6.3f;
    [SerializeField]
    private float fieldMaximumX = 3.3f;
    [SerializeField]
    private float fieldMaximumY = 4.4f;
    [SerializeField]
    private float fieldMinimumY = -5.4f;


    public CircleCollider2D circleCollider
    {
        private set;
        get;
    }
    private bool canMove;
    

    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (canMove)
        {
            if ((movement.x > 0f && transform.position.x > fieldMaximumX) ||
                (movement.x < 0f && transform.position.x < fieldMinimumX))
            {
                movement = new Vector2(-movement.x, movement.y) ;
            }

            if (movement.y > 0f && transform.position.y > fieldMaximumY + 0.1f)
            {
                movement = new Vector2(movement.x, -movement.y);
            }

            if (movement.y < 0f && transform.position.y < fieldMinimumY + 0.1f)
            {
                BallOutOfBounderies.Raise();
            }

        
            transform.Translate(movement * speed * Time.deltaTime);
        } 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            OnHitPaddle(collision);
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

    private void RandomMovement()
    {
        var x = Random.Range(-0.8f, 0.8f);
        var up = 1;
        movement = new Vector2(x, up).normalized;

        Move();
    }
}

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

    [SerializeField]
    public Vector2 startPosition;
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
    private float currentSpeed;


    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        currentSpeed = speed;
    }

    void Update()
    {
        if (canMove)
        {
            if ((movement.x > 0f && transform.position.x > fieldMaximumX) ||
                (movement.x < 0f && transform.position.x < fieldMinimumX))
            {
                movement = new Vector2(-movement.x, movement.y);
            }

            if (movement.y > 0f && transform.position.y > fieldMaximumY + 0.1f)
            {
                movement = new Vector2(movement.x, -movement.y);
            }

            if (movement.y < 0f && transform.position.y < fieldMinimumY + 0.1f)
            {
                BallGotOutOfBoundaries();
            }
        
            transform.Translate(movement * currentSpeed * Time.deltaTime);
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
    
    public void SlowByFactor(float factor)
    {
        currentSpeed = factor * currentSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
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

    private void BallGotOutOfBoundaries()
    {
        canMove = false;
        transform.parent = null;
        BallOutOfBounderies.Raise();
        Destroy(gameObject);
    }

    private void RandomMovement()
    {
        var x = Random.Range(-0.8f, 0.8f);
        var up = 1;
        movement = new Vector2(x, up).normalized;

        Move();
    }
}

using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPosition;
    [SerializeField]
    private Transform rightStartReflection;
    [SerializeField]
    private Transform rightEndReflection;
    [SerializeField] 
    private Transform leftStartReflection;
    [SerializeField]
    private Transform leftEndReflection;

    private BoxCollider2D boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        transform.position = startPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            var powerUp = collision.gameObject.GetComponent<PowerUpBehaviuor>();
            powerUp.Colect();
        }

        if(collision.gameObject.CompareTag("Ball"))
        {
            var ball = collision.gameObject.GetComponent<BallBehaviour>();

            var movement = ReflectOnPaddle(ball.transform.position);

            ball.Move(movement);
        }
    }

    private Vector2 ReflectOnPaddle(Vector2 ballPosition)
    {
        var deltaX = Mathf.Abs(ballPosition.x - transform.position.x);
        var halfPaddleWidth = boxCollider.bounds.size.x / 2;
        var interpolant = deltaX / halfPaddleWidth;
        var targetDirection = Vector2.zero;

        var isOnLeft = ballPosition.x - transform.position.x < 0;
        if (isOnLeft)
        {
            targetDirection = Vector3.Lerp(leftStartReflection.position, leftEndReflection.position, interpolant);
        }
        else
        {
            targetDirection = Vector3.Lerp(rightStartReflection.position, rightEndReflection.position, interpolant);
        }

        return (targetDirection - ballPosition).normalized;
    }
}

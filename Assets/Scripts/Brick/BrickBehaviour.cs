using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Collections.AllocatorManager;

public class BrickBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameEvent onBrickBroke;
    [SerializeField]
    private BrickScriptableObject brick;
    [SerializeField]
    private GameObject graphics;
    
    public GameObject ballConext;

    private BallBehaviour[] balls;
    private PowerUpDropperBehaviour powerUp;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private bool isBroken;

    private int hitCount = 0;

    void Awake()
    {
        isBroken = false;
        powerUp = GetComponent<PowerUpDropperBehaviour>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.color = brick.color;

        balls = ballConext.GetComponentsInChildren<BallBehaviour>();
    }

    void Start()
    {
        ResetBrick();
    }

    void Update()
    {
        if(!isBroken)
        {
            foreach (BallBehaviour ball in balls)
            {
                if (CheckCollision(ball))
                {
                    HitBall(ball);
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HitBrick();
        }
    }

    public void OnDisruption()
    {
        GetBall();
    }

    private void GetBall()
    {
        balls = ballConext.GetComponentsInChildren<BallBehaviour>();
    }

    private bool CheckCollision(BallBehaviour ball)
    {
        var distance = new Vector2(
            Mathf.Abs(ball.transform.position.x - transform.position.x),
            Mathf.Abs(ball.transform.position.y - transform.position.y)
        );

        var halfWidth = boxCollider.size.x / 2;
        var halfHight = boxCollider.size.y / 2;

        if (distance.x > halfWidth + ball.circleCollider.radius)
        {
            return false;
        }
        if (distance.y > halfHight + ball.circleCollider.radius)
        {
            return false;
        }
        if (distance.x <= halfWidth)
        {
            return true;
        }
        if (distance.y <= halfHight)
        {
            return true;
        }

        var cornerDistanceSquared = Mathf.Pow(distance.x - halfWidth, 2) + Mathf.Pow(distance.y - halfHight, 2);

        return cornerDistanceSquared <= Mathf.Pow(ball.circleCollider.radius, 2);

    }

    private void HitBall(BallBehaviour ball)
    {
        var delta = (ball.transform.position - transform.position);
        // apply aspect ratio via the scaleFactor vector
        // For a horizontal block twice a wide as high, use Vector3(0.5f, 1f, 1f)
        // For a vertical block twice as high as wide, use Vector3(1f, 0.5f, 1f)
        // For a square block, use Vector3(1f, 1f, 1f), and so forth.
        var scaleFactor = new Vector3(boxCollider.size.y / boxCollider.size.x, 1f, 1f);
        delta.Scale(scaleFactor);
        if (Mathf.Abs(delta.x) >= Mathf.Abs(delta.y))
        {
            // scaled delta x was larger than delta y. This is a horizontal hit.
            if (Mathf.Sign(-ball.movement.x) == Mathf.Sign(delta.x))
            {
                ball.Move(new Vector2(-ball.movement.x, ball.movement.y));
                HitBrick();
            }
        }
        else
        {
            // scaled delta y was larger than delta x. This is a vertical hit.
            if (Mathf.Sign(-ball.movement.y) == Mathf.Sign(delta.y))
            {
                ball.Move(new Vector2(ball.movement.x, -ball.movement.y));
                HitBrick();
            }
        }
    }

    private void HitBrick()
    {
        hitCount++;
        if (hitCount >= brick.resistence)
        {
            onBrickBroke.Raise();
            powerUp.DropPowerUp();
            graphics.SetActive(false);
            boxCollider.enabled = false;
            isBroken = true;
        }
    }

    private void ResetBrick()
    {
        boxCollider.enabled = true;
        graphics.SetActive(true);
        hitCount = 0;
        isBroken = false;
    }    
}

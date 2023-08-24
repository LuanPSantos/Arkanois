using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HittedByBallDetectionBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject ballConext;
    [SerializeField]
    private UnityEvent onHit;
    private BoxCollider2D boxCollider;
    private BallBehaviour[] balls = new BallBehaviour[0];

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if(ballConext != null)
        {
            balls = ballConext.GetComponentsInChildren<BallBehaviour>();
        }
        
    }

    void Update()
    {
        foreach (BallBehaviour ball in balls)
        {
            if (CheckCollision(ball))
            {
                Reflect(ball);
                onHit?.Invoke();
            }
        }
    }

    public void OnDisruption()
    {
        GetBall();
    }

    public void OnBallOfBoundaries()
    {
        GetBall();
    }

    public void EnableDetection()
    {
        UpdateNavigationGrid();
        boxCollider.enabled = true;
        enabled = true;
    }

    public void DisableDetection()
    {
        UpdateNavigationGrid();
        boxCollider.enabled = false;
        enabled = false;
    }

    public void SetBallContext(GameObject ballContext)
    {
        this.ballConext = ballContext;
        GetBall();
    }

    private void UpdateNavigationGrid()
    {
        var bounds = boxCollider.bounds;
        bounds.Expand(Vector3.forward * 1000);
        var guo = new GraphUpdateObject(bounds);
        AstarPath.active.UpdateGraphs(guo);
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

        //horizontal hit?
        if (distance.x <= halfWidth)
        {
            return true;
        }

        //vertical hit?
        if (distance.y <= halfHight)
        {
            return true;
        }

        var cornerDistanceSquared = Mathf.Pow(distance.x - halfWidth, 2) + Mathf.Pow(distance.y - halfHight, 2);

        return cornerDistanceSquared <= Mathf.Pow(ball.circleCollider.radius, 2);

    }

    private void Reflect(BallBehaviour ball)
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
                //Reflect if ball in going to de brick, and not going away
                ball.Move(ClampReflect(ball.movement, new Vector2(-ball.movement.x, ball.movement.y), true));
            }
        }
        else
        {
            // scaled delta y was larger than delta x. This is a vertical hit.
            if (Mathf.Sign(-ball.movement.y) == Mathf.Sign(delta.y))
            {
                ball.Move(ClampReflect(ball.movement, new Vector2(ball.movement.x, -ball.movement.y), false));
            }
        }
    }

    private Vector2 ClampReflect(Vector2 currentDirection, Vector2 newDirection, bool isHorizontal)
    {
     
        var offset = 0.866; // Dot of 30 degrees

        var dot = Vector2.Dot(currentDirection, newDirection);

        //angle not too open not too close
        if(dot > -1 + offset && dot < 1 - offset)
        {
            return newDirection;
        }

        var angle = Vector2.Angle(currentDirection, newDirection);
        angle = ClampBallAngle(angle);
        var campledDirection = newDirection;

        if (isHorizontal)
        {
            if(currentDirection.x > 0 && currentDirection.y > 0 || currentDirection.x < 0 && currentDirection.y < 0)
            {
                campledDirection = Rotate(currentDirection, angle);
            }
            if (currentDirection.x < 0 && currentDirection.y > 0 || currentDirection.x > 0 && currentDirection.y < 0)
            {
                campledDirection = Rotate(currentDirection, -angle); 
            }   
        }
        else
        {
            if (currentDirection.x > 0 && currentDirection.y > 0 || currentDirection.x < 0 && currentDirection.y < 0)
            {
                campledDirection = Rotate(currentDirection, -angle);
            }
            if (currentDirection.x < 0 && currentDirection.y > 0 || currentDirection.x > 0 && currentDirection.y < 0)
            {
                campledDirection = Rotate(currentDirection, angle);
            }
        }

        return campledDirection;
    }

    private float ClampBallAngle(float angle)
    {
        if (angle > 150f)
        {
            return 150f;
        }
        if (angle < 30f)
        {
            return 30f;
        }
        
        return angle;
    }

    private Vector3 Rotate(Vector3 direction, float angle)
    {
        return Quaternion.AngleAxis(angle, Vector3.forward) * direction;
    }
}

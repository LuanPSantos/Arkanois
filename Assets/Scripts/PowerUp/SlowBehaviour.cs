using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBehaviour : MonoBehaviour
{
    [SerializeField]
    private float slowFactor;

    private BallBehaviour ball;
    private float originalSpeed;
    private float currentSpeed;

    void Awake()
    {
        ball = GetComponent<BallBehaviour>();
        originalSpeed = ball.speed;
        currentSpeed = ball.speed;
    }

    public void OnSlowEnabled()
    {
        currentSpeed = slowFactor * currentSpeed;
        ball.speed = currentSpeed;
    }

    public void OnSlowDisabled()
    {
        ball.speed = originalSpeed;
    }
}

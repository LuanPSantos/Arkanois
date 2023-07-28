using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBehaviour : MonoBehaviour
{
    [SerializeField]
    private float slowFactor;

    private BallBehaviour ball;

    void Awake()
    {
        ball = GetComponent<BallBehaviour>();
    }

    public void OnSlowEnabled()
    {
        ball.SlowByFactor(slowFactor);
    }

    public void OnSlowDisabled()
    {
        ball.ResetSpeed();
    }
}

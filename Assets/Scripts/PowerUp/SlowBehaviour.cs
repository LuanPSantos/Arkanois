using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBehaviour : MonoBehaviour
{
    [SerializeField]
    private float slowFactor;

    private BallBehaviour ballBehaviour;
    private float originalSpeed;
    private float currentSpeed;

    void Awake()
    {
        ballBehaviour = GetComponent<BallBehaviour>();
        originalSpeed = ballBehaviour.GetSpeed();
        currentSpeed = ballBehaviour.GetSpeed();
    }

    public void OnSlowEnabled()
    {
        ballBehaviour.SetSpeed(slowFactor * currentSpeed);
        currentSpeed = ballBehaviour.GetSpeed();
    }

    public void OnSlowDisabled()
    {
        ballBehaviour.SetSpeed(originalSpeed);
    }
}

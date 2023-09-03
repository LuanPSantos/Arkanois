using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBehaviour : MonoBehaviour
{
    [SerializeField]
    private float slowFactor;
    [SerializeField]
    private float powerUpDuration;

    private BallBehaviour ball;

    private bool isActive = false;
    private float durationTimer;

    void Awake()
    {
        ball = GetComponent<BallBehaviour>();
    }

    void Update()
    {
        if (!isActive) return;

        durationTimer += Time.deltaTime;
        if (durationTimer > powerUpDuration)
        {
            OnSlowDisabled();
        }
    }

    public void OnSlowEnabled()
    {
        ball.SlowByFactor(slowFactor);
        durationTimer = 0;
        isActive = true;
    }

    public void OnSlowDisabled()
    {
        ball.ResetSpeed();
        durationTimer = 0;
        isActive = false;
    }
}

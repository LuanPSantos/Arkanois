using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptionBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private float angleInDegree = 15;

    private BallBehaviour ball;

    void Start()
    {
        ball = GetComponent<BallBehaviour>();
    }

    public void OnDisruptionEnabled()
    {
        InstantiateBallMovingByAngle(angleInDegree);

        InstantiateBallMovingByAngle(-angleInDegree);
    }

    private void InstantiateBallMovingByAngle(float angle)
    {
        var newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        
        var movement = (Quaternion.Euler(new Vector3(0, 0, angle)) * ball.movement).normalized;
        
        newBall.GetComponent<BallBehaviour>().Move(movement);
    }
}

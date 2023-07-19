using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptionBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    private BallBehaviour ball;

    void Start()
    {
        ball = GetComponent<BallBehaviour>();
    }

    public void OnDisruptionEnabled()
    {
        Debug.Log("rb.velocity " + ball.GetMovement());
        var secondBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        var movement = Quaternion.Euler(new Vector3(0, 0, 15)) * ball.GetMovement();
        secondBall.GetComponent<BallBehaviour>().Move(movement.normalized);

        var thirdBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        movement = Quaternion.Euler(new Vector3(0, 0, -15)) * ball.GetMovement();
        thirdBall.GetComponent<BallBehaviour>().Move(movement.normalized);
    }
}

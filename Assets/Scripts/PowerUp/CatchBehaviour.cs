using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatchBehaviour : MonoBehaviour
{
    [SerializeField]
    private float timeToReleaseBall;

    private BallBehaviour ball;
    private InputAction actionInput; // TODO reapoveitar codigo
    private PaddleControls controls;
    private bool isActive;
    private bool isHoldingBall;
    private float yPaddle = -3.75f;
    private float timer = 0;


    void Awake()
    {
        ball = GetComponent<BallBehaviour>();
        isActive = false;
        controls = new PaddleControls();
        actionInput = controls.Gameplay.Action;
    }

    void Update()
    {
        if(isActive && isHoldingBall)
        {
            timer += Time.deltaTime;

            if(timer > timeToReleaseBall)
            {
                timer = 0;

                ball.Move();
            }
        }
    }

    public void OnCatchEnabled()
    {
        isActive = true;
        actionInput.performed += OnInputAction;
        actionInput.Enable();
    }

    public void OnCatchDisabled()
    {
        isActive = false;
        actionInput.performed -= OnInputAction;
        actionInput.Disable();
        ball.Move();
    }

    public void OnInputAction(InputAction.CallbackContext context)
    {
        ball.Move();
        ball.transform.parent = null;
        isHoldingBall = false;
        timer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle") && isActive)
        {
            isHoldingBall = true;
            ball.Stop();
            ball.transform.parent = collision.gameObject.transform;
            ball.transform.position = new Vector2(ball.transform.position.x, yPaddle);
        }
    }
}

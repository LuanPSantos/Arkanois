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

    void OnEnable()
    {
        actionInput.performed += OnInputAction;
    }

    void OnDisable()
    {
        actionInput.performed -= OnInputAction;
    }

    public void OnCatchEnabled()
    {
        actionInput.Enable();

        isActive = true;
    }

    public void OnCatchDisabled()
    {
        actionInput.Disable();
        
        isActive = false;

        ReleaseBall();
    }

    public void OnInputAction(InputAction.CallbackContext context)
    {
        ReleaseBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle") && isActive)
        {
            CatchBall(collision.gameObject.transform);
        }
    }

    private void ReleaseBall()
    {
        ball.transform.parent = null;
        ball.Move();

        isHoldingBall = false;
        timer = 0;
    }

    private void CatchBall(Transform parent)
    {
        ball.transform.parent = parent;
        ball.transform.position = new Vector2(ball.transform.position.x, ball.startPosition.y);
        ball.Stop();

        isHoldingBall = true;
    }
}

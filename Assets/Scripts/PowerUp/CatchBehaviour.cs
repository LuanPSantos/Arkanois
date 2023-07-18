using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatchBehaviour : MonoBehaviour
{
    private BallBehaviour ball;

    private InputAction actionInput; // TODO reapoveitar codigo
    private PaddleControls controls;
    private bool isActive;

    void Awake()
    {
        ball = GetComponent<BallBehaviour>();
        isActive = false;
        controls = new PaddleControls();
        actionInput = controls.Gameplay.Action;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle") && isActive)
        {
            ball.Stop();
            ball.transform.parent = collision.gameObject.transform;
        }
    }
}

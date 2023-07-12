using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool canMove = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void OnInputMove(InputAction.CallbackContext context) {
        if(canMove)
        {
            movement = context.ReadValue<Vector2>();
        }
    }

    public void OnStateChange(GameplayManager.State state)
    {
        switch (state)
        {
            case GameplayManager.State.IN_GAME:
                OnInGame();
                break;
            default:
                OnStateChangeDefault();
                break;
        }
    }

    public void OnInGame()
    {
        canMove = true;
    }

    public void OnStateChangeDefault()
    {
        canMove = false;
        movement = Vector2.zero;
    }

    void FixedUpdate() {
        rb.velocity = movement * speed;
    }
}

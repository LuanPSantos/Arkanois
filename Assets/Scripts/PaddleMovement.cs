using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool canMove = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Stop();
    }

    public void OnInputMove(InputAction.CallbackContext context)
    {
        if (canMove)
        {
            movement = context.ReadValue<Vector2>();
        }
    }

    public void OnGameStarded()
    {
        Move();
    }

    public void OnGameEnded()
    {
        Stop();
    }

    public void OnGameLost()
    {
        Stop();
    }

    private void Move()
    {
        canMove = true;
    }

    private void Stop()
    {
        canMove = false;
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            rb.velocity = movement * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}

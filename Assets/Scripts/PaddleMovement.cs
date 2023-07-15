using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private InputAction movement;

    private PaddleControls controls;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PaddleControls();
        movement = controls.Gameplay.Movement;
    }

    void Start()
    {
        Stop();
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
        movement.Enable();
    }

    private void Stop()
    {
        movement.Disable();
    }

    void FixedUpdate()
    {
        rb.velocity = movement.ReadValue<Vector2>() * speed;
    }
}

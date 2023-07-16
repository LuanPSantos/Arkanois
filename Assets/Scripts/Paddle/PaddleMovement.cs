using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private InputAction movementInput;

    private PaddleControls controls;
    private Vector2 lastPosition;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PaddleControls();
        movementInput = controls.Gameplay.Movement;
    }

    void Start()
    {
        Stop();
    }

    private void Update()
    {
        movement = movementInput.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        lastPosition = transform.position;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            movement = Vector2.zero;
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
        movementInput.Enable();
    }

    private void Stop()
    {
        movementInput.Disable();
    }
}

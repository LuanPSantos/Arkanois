using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float fieldMinimumX;
    [SerializeField] 
    private float fieldMaximumX;

    private InputAction movementInput;

    private PaddleControls controls;
    private Vector2 movement;
    private BoxCollider2D boxCollider;

    void Awake()
    {
        controls = new PaddleControls();
        movementInput = controls.Gameplay.Movement;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        Stop();
    }

    void Update()
    {
        movement = movementInput.ReadValue<Vector2>();
        var halfPaddleSize = boxCollider.bounds.size.x / 2;

        if (movement.x > 0f && transform.position.x >= fieldMaximumX - halfPaddleSize ||
            movement.x < 0f && transform.position.x <= fieldMinimumX + halfPaddleSize) 
        {
            movement = Vector2.zero;
        }

        if (transform.position.x >= fieldMaximumX - halfPaddleSize)
        {
            transform.position = new Vector3(fieldMaximumX - halfPaddleSize, transform.position.y, transform.position.z);
        }
        if(transform.position.x <= fieldMinimumX + halfPaddleSize)
        {
            transform.position = new Vector3(fieldMinimumX + halfPaddleSize, transform.position.y, transform.position.z);
        }

        transform.Translate(movement * speed * Time.deltaTime);
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

    public void OnGamePaused()
    {
        Stop();
    }

    public void OnGameResumed(object state)
    {
        if((GameManagerScriptableObject.State)state == GameManagerScriptableObject.State.IN_GAME)
        {
            Move();
        }
        
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

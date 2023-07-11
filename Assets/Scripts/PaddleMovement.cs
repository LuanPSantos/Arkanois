using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{

    public float speed;
    

    private Rigidbody2D rb;

    private Vector2 movement;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void OnMove(InputAction.CallbackContext context) {
        movement = context.ReadValue<Vector2>();
    }

    void FixedUpdate() {
        rb.velocity = movement * speed;
    }
}

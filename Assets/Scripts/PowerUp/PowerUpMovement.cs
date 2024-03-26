using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private GameEvent powerUpDestroyed;
    [SerializeField]
    private float fieldMinimumY = -5.5f;

    void Update()
    {

        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < fieldMinimumY)
        {
            powerUpDestroyed.Raise();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            powerUpDestroyed.Raise();
            Destroy(gameObject);
        }
    }
}

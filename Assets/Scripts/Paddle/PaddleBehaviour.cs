using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    public Vector2 startPosition;
    void Start()
    {
        //TODO test
        //transform.position = startPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            var powerUp = collision.gameObject.GetComponent<PowerUpBehaviuor>();

            powerUp.Colect();
        }
    }
}

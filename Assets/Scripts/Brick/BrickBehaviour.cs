using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameEvent onBrickBroke;
    [SerializeField]
    private BrickScriptableObject brick;
    [SerializeField]
    private GameObject graphics;
    [SerializeField]
    private GameObject powerUp;
    [SerializeField]
    private int dropPowerUpProbability;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private int hitCount = 0;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    void Start()
    {
        spriteRenderer.color = brick.color;

        ResetBrick();
    }

    private void ResetBrick()
    {
        boxCollider.enabled = true;
        graphics.SetActive(true);
        hitCount = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;
            if (hitCount >= brick.resistence)
            {
                onBrickBroke.Raise();

                boxCollider.enabled = false;
                graphics.SetActive(false);

                DropPowerUp();
            }
        }
    }

    private void DropPowerUp()
    {
        var random = Random.Range(0, 100);
       
        if(random <= dropPowerUpProbability)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity, null);
        }
    }
}

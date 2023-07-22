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
    
    private PowerUpDropperBehaviour powerUp;
    private SpriteRenderer spriteRenderer;

    private int hitCount = 0;

    void Awake()
    {
        powerUp = GetComponent<PowerUpDropperBehaviour>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = brick.color;
    }

    void Start()
    {
        ResetBrick();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HitBrick();
        }
    }

    public void HitBrick()
    {
        hitCount++;
        if (hitCount >= brick.resistence)
        {
            onBrickBroke.Raise();
            powerUp.DropPowerUp();
            graphics.SetActive(false);
        }
    }

    private void ResetBrick()
    {
        graphics.SetActive(true);
        hitCount = 0;
    }    
}

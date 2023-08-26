using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Collections.AllocatorManager;

public class BrickBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameEvent onBrickBroke;
    [SerializeField]
    private BrickScriptableObject brick;
    [SerializeField]
    private GameObject graphics;
    [SerializeField]
    private bool isBreakable = true;
    [SerializeField]
    private int score;

    private ScorePopUpBehaviour scorePopUpBehaviour;   
    private PowerUpDropperBehaviour powerUp;
    private SpriteRenderer spriteRenderer;
    private HittedByBallDetectionBehaviour hitDetection;

    private int hitCount = 0;

    void Awake()
    {
        powerUp = GetComponent<PowerUpDropperBehaviour>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        hitDetection = GetComponent<HittedByBallDetectionBehaviour>();
        scorePopUpBehaviour = GetComponent<ScorePopUpBehaviour>();

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
            OnBrickHitted();
        }
    }

    public void OnBrickHitted()
    {
        if (!isBreakable) return;

        hitCount++;
        if (hitCount >= brick.resistence)
        {
            onBrickBroke.Raise(score);
            scorePopUpBehaviour.OnScore(score);
            powerUp.DropPowerUp();
            graphics.SetActive(false);
            hitDetection.DisableDetection();
        }
    }

    private void ResetBrick()
    {
        hitDetection.EnableDetection();
        graphics.SetActive(true);
        hitCount = 0;
    }    
}

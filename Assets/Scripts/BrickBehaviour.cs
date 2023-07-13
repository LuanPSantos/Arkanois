using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickBehaviour : MonoBehaviour
{
    public GameEvent onBrickHitted;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private List<Color> colors = new List<Color>();

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();

        colors.Add(new Color(150 / 255f, 40 / 255f, 40 / 200f));
        colors.Add(new Color(225 / 255f, 145 / 255f, 15 / 200f));
        colors.Add(new Color(90 / 255f, 200 / 255f, 200 / 200f));
        colors.Add(new Color(190 / 255f, 90 / 255f, 160 / 200f));
    }

    void Start()
    {
        spriteRenderer.color = colors[Random.Range(0, colors.Count)];

        ResetBrick();
    }

    private void ResetBrick()
    {
        boxCollider.enabled = true;
        spriteRenderer.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBrickHitted.Raise();

            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
    }
}

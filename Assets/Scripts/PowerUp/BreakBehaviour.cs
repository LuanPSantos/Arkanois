using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameEvent levelBreaked;
    [SerializeField]
    private GameObject graphics;
    private BoxCollider2D boxCollider;
    

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        graphics.SetActive(false);
    }

    public void OnBreakEnabled()
    {
        boxCollider.enabled = true;
        graphics.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            levelBreaked.Raise();
        }
    }
}

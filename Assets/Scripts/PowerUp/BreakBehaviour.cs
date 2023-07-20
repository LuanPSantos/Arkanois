using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameEvent levelBreaked;
    [SerializeField]
    private GameObject graphics;
    

    void Start()
    {
        graphics.SetActive(false);
    }

    public void OnBreakEnabled()
    {
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

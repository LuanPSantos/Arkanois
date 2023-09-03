using System.Collections;
using System;
using UnityEngine;

public class PowerUpDropperBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPowerUp;
    [SerializeField]
    private GameObject disruptionPowerUp;
    [SerializeField]
    private GameObject enlargePowerUp;
    [SerializeField]
    private GameObject catchPowerUp;
    [SerializeField]
    private GameObject slowPowerUp;
    [SerializeField]
    private int dropPowerUpProbability;
    [SerializeField]
    private GameEvent powerUpDropped;

    private bool canDrop;
    private System.Random random;

    void Start()
    {
        random = new System.Random();
        canDrop = true;
    }

    public void OnDisabelDrop()
    {
        canDrop = false;
    }

    public void OnEnableDrop()
    {
        canDrop = true;
    }

    public void DropPowerUp()
    {
        if (!canDrop) return;

        var picked = random.Next(0, 100);

        if (picked % 30 == 0)
        {
            Drop(laserPowerUp);
        }
        else if (picked % 6 == 0)
        {
            Drop(disruptionPowerUp);
        }
        else if (picked % 5 == 0)
        {
            Drop(enlargePowerUp);
        }
        else if (picked % 4 == 0)
        {
            Drop(catchPowerUp);
        }
        else if (picked % 3 == 0)
        {
            Drop(slowPowerUp);
        }  
    }

    private void Drop(GameObject powerUp)
    {
        Instantiate(powerUp, transform.position, Quaternion.identity, null);
        powerUpDropped.Raise();
    }
}

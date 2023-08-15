using System.Collections;
using System;
using UnityEngine;

public class PowerUpDropperBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject breakPowerUp;
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
        Debug.LogWarning("OnDisabelDrop " + canDrop);
        canDrop = false;
    }

    public void OnEnableDrop()
    {
        Debug.LogWarning("OnEnableDrop " + canDrop);
        canDrop = true;
    }

    public void DropPowerUp()
    {
        Debug.LogWarning("DropPowerUp " + canDrop);
        if (!canDrop) return;

        

        var picked = random.Next(0, 100);

        Debug.LogWarning("picked " + picked);

        if (picked % 19 == 0)
        {
            Instantiate(breakPowerUp, transform.position, Quaternion.identity, null);
        }
        else if(picked % 20 == 0)
        {
            Instantiate(laserPowerUp, transform.position, Quaternion.identity, null);
        }
        else if (picked % 6 == 0)
        {
            Instantiate(disruptionPowerUp, transform.position, Quaternion.identity, null);
        }
        else if (picked % 5 == 0)
        {
            Instantiate(enlargePowerUp, transform.position, Quaternion.identity, null);
        }
        else if (picked % 4 == 0)
        {
            Instantiate(catchPowerUp, transform.position, Quaternion.identity, null);
        }
        else if (picked % 3 == 0)
        {
            Instantiate(slowPowerUp, transform.position, Quaternion.identity, null);
        }

        powerUpDropped.Raise();      
    }
}

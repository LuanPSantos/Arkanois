using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDropperBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> powerUps;
    [SerializeField]
    private int dropPowerUpProbability;

    private bool canDrop;

    void Start()
    {
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
        var random = Random.Range(0, 100);

        if (random % (100 / dropPowerUpProbability) == 0 && canDrop)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Count)], transform.position, Quaternion.identity, null);
        }
    }
}

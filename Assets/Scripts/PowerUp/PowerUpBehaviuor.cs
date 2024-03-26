using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviuor : MonoBehaviour
{

    [SerializeField]
    private GameEvent powerUpColected;
    
    public void Colect()
    {
        powerUpColected.Raise();
    }
}

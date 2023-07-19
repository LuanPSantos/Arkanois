using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPowerUpBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameManagerScriptableObject gameManger;
    
    public void OnPlayerPowerUpColected()
    {
        gameManger.IncreasePlayerLife();
    }
}

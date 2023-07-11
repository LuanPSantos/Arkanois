using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    public Vector2 startPosition;
    
    public void OnStateChange(GameplayManager.State state) {
        switch(state) {
            case GameplayManager.State.WAITING_GAMEPLAY:
                transform.position = startPosition;
                break;
            default:
                break;
        }
    }
}

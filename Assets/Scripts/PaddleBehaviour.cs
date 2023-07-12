using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    public Vector2 startPosition;
    
    public void OnStateChange(GameplayManager.State state) {
        switch(state) {
            case GameplayManager.State.WAITING_GAMEPLAY:
                OnWaitingGameplay();
                break;
            default:
                break;
        }
    }

    private void OnWaitingGameplay()
    {
        transform.position = startPosition;
    }
}

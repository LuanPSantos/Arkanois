using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BricksManager : MonoBehaviour
{
    public UnityEvent OnAllBricksBroken;

    private int amoutActivedBricks = 0;
    private BrickBehaviour[] bricks;

    void Awake()
    {
        bricks = GetComponentsInChildren<BrickBehaviour>();
        
        for(int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].enabled)
            {
                amoutActivedBricks++;
            }
        }
    }

    public void OnStateChange(GameplayManager.State state) {
        switch(state) 
        {
            case GameplayManager.State.WAITING_GAMEPLAY:
                OnWaitingGameplay();
                break;
            default:
                break;
        }
    }

    public void OnBrickHitted()
    {
        amoutActivedBricks--;

        if (amoutActivedBricks == 0)
        {
            OnAllBricksBroken?.Invoke();
        }
    }

    private void OnWaitingGameplay()
    {
        foreach (BrickBehaviour brick in bricks)
        {
            brick.Reset(); // Cada brick poderia responder por si so quando o game state mudar para WAITING_GAMEPLAY
        }

        amoutActivedBricks = bricks.Length;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BricksManager : MonoBehaviour
{
    public UnityEvent OnAllBricksBroken;

    private int amoutActivedBricks = 0;

    void Start()
    {
        amoutActivedBricks = GetComponentsInChildren<BrickBehaviour>().Length;
    }

    public void OnStateChange(GameplayManager.State state) {
        switch(state) {
            case GameplayManager.State.WAITING_GAMEPLAY:
                var bricks = GetComponentsInChildren<BrickBehaviour>();

                foreach(BrickBehaviour brick in bricks) {
                    brick.Reset();
                }

                amoutActivedBricks = bricks.Length;

                break;
            default:
                break;
        }
    }

    public void DecreaseAmountActivedBricks()
    {
        amoutActivedBricks--;
        Debug.Log("BricksManager-DecreaseAmountActivedBricks, amoutActivedBricks=" + amoutActivedBricks);

        if (amoutActivedBricks == 0)
        {
            OnAllBricksBroken?.Invoke();
        }
    }
}

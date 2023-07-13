using UnityEngine;
using UnityEngine.Events;

public class BricksManager : MonoBehaviour
{
    public GameEvent onAllBricksBroke;

    private int amoutActivedBricks = 0;
    private BrickBehaviour[] bricks;

    void Awake()
    {
        bricks = GetComponentsInChildren<BrickBehaviour>();

        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].enabled)
            {
                amoutActivedBricks++;
            }
        }
    }
    public void OnBrickHitted()
    {
        amoutActivedBricks--;

        if (amoutActivedBricks == 0)
        {
            onAllBricksBroke.Raise();
        }
    }
}

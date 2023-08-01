using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BricksManager : MonoBehaviour
{
    public GameEvent onAllBricksBroke;

    private Queue<int> activeBricks = new Queue<int>();

    void Awake()
    {
        var bricks = GetComponentsInChildren<BrickBehaviour>();

        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].enabled)
            {
                activeBricks.Enqueue(i);
            }
        }
    }
    public void OnBrickBroke()
    {
        if (activeBricks.Count <= 0) return;
        
        activeBricks.Dequeue();

        if (activeBricks.Count == 0)
        {
            onAllBricksBroke.Raise();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameManagerScriptableObject : ScriptableObject
{
    public GameEvent gameLost;
    public GameEvent gameEnded;

    public void OnAllBricksBroke()
    {
        Debug.Log("OnAllBricksBroke.gameEnded");
        gameEnded.Raise();
    }

    public void OnBallOutOffBaudaries()
    {
        Debug.Log("OnBallOutOffBaudaries.gameLost");
        gameLost.Raise();
    }
}

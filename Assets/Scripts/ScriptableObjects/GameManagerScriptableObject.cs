using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class GameManagerScriptableObject : ScriptableObject
{
    [SerializeField]
    private GameEvent gameStarted;
    [SerializeField]
    private GameEvent gameLost;
    [SerializeField]
    private GameEvent gameEnded;
    [SerializeField]
    private GameEvent disruptivePowerUpEnded;
    [SerializeField]
    private int ballsInGame;
    [SerializeField]
    private int playerLives;

    private PaddleControls controls;

    void OnEnable()
    {
        controls = new PaddleControls();
        controls.GameStart.Start.performed += StartGame;
    }

    void OnDisable()
    {
        controls.GameStart.Start.performed -= StartGame;
    }

    public void OnLevelLoaded()
    {
        controls.GameStart.Start.Enable();
    }

    public void OnAllBricksBroke()
    {
        gameEnded.Raise();
    }

    public void OnBallOutOffBaudaries()
    {
        ballsInGame--;
        if(ballsInGame == 0)
        {
            gameLost.Raise();
        } 
        if(ballsInGame == 1)
        {
            disruptivePowerUpEnded.Raise();
        }
    }

    public void OnDisruption()
    {
        ballsInGame = 3;
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        controls.GameStart.Start.Disable();
        gameStarted.Raise();
    }
}

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
    private GameEvent gameRestarted;
    [SerializeField]
    private GameEvent disruptionPowerUpEnded;
    [SerializeField]
    private int playerExtraLifes;

    private PaddleControls controls;
    private InputAction actionInput;
    public int ballsInGame;

    void OnEnable()
    {
        controls = new PaddleControls();
        actionInput = controls.GameStart.Start;

        actionInput.performed += StartGame;
    }

    void OnDisable()
    {
        actionInput.performed -= StartGame;
    }

    public void BeforeFirstLevel()
    {
        playerExtraLifes = 0;
    }

    public void OnLevelLoaded()
    {
        ballsInGame = 1;
        actionInput.Enable();
    }

    public void OnAllBricksBroke()
    {
        gameEnded.Raise();
    }

    public void OnBallOutOffBaudaries()
    {
        ballsInGame--;

        CheckGameOver();
        CheckDisruptionOver();
    }

    public void OnDisruption()
    {
        ballsInGame = 3;
        Debug.Log("ballsInGame " + ballsInGame);
    }

    public void IncreasePlayerLife()
    {
        playerExtraLifes++;
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        actionInput.Disable();
        gameStarted.Raise();
    }

    private void CheckGameOver()
    {
        if (ballsInGame == 0)
        {
            if (playerExtraLifes > 0)
            {
                playerExtraLifes--;
                gameRestarted.Raise();
            }
            else
            {
                BeforeFirstLevel();
                gameLost.Raise();
            }
        }
    }

    private void CheckDisruptionOver()
    {
        if (ballsInGame == 1)
        {
            disruptionPowerUpEnded.Raise();
        }
    }
}

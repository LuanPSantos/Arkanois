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
    private GameEvent gamePaused;
    [SerializeField]
    private GameEvent gameResumed;
    [SerializeField]
    private GameEvent disruptionPowerUpEnded;

    private PaddleControls controls;
    private InputAction startInputAction;
    private InputAction pauseInputAction;
    private int ballsInGame;
    private State state;

    void OnEnable()
    {
        controls = new PaddleControls();
        startInputAction = controls.GameStart.Start;
        pauseInputAction = controls.Gameplay.Pause;

        startInputAction.performed += StartGame;
        pauseInputAction.performed += PauseGame;
    }

    void OnDisable()
    {
        startInputAction.performed -= StartGame;
        pauseInputAction.performed -= PauseGame;
    }

    public void OnLevelLoaded()
    {
        state = State.READY;
        ballsInGame = 1;
        startInputAction.Enable();
        pauseInputAction.Enable();
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
    }

    public void ResumeGame()
    {
        if (state == State.READY)
        {
            startInputAction.Enable();
        }

        gameResumed.Raise(state);
    }

    private void StartGame(InputAction.CallbackContext context)
    {
        startInputAction.Disable();

        state = State.IN_GAME;

        gameStarted.Raise();
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        if(state == State.READY)
        {
            startInputAction.Disable();
        }

        gamePaused.Raise();
    }

    private void CheckGameOver()
    {
        if (ballsInGame == 0)
        {
            gameLost.Raise();
        }
    }

    private void CheckDisruptionOver()
    {
        if (ballsInGame == 1)
        {
            disruptionPowerUpEnded.Raise();
        }
    }

    public enum State
    {
        READY, IN_GAME
    }
}

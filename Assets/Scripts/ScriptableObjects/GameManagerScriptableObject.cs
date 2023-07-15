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
        gameLost.Raise();
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        controls.GameStart.Start.Disable();
        gameStarted.Raise();
    }
}

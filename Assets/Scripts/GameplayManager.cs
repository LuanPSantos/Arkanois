using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameplayManager : MonoBehaviour
{
    public UnityEvent<State> onStateChange;
    public PlayerInput playerInput;
    
    void Start()
    {
        LoadGameplay();
    }

    public void LoadGameplay() {
        ChangeStateTo(State.WAITING_GAMEPLAY);
    }

    public void OnInputStartGame() {
        Debug.Log("GameplayManager-StartGame");

        playerInput.SwitchCurrentActionMap("Paddle");

        ChangeStateTo(State.IN_GAME);
    }

    public void OnAllBricksBroken() {
        Debug.Log("GameplayManager-OnAllBricksBroken");
        playerInput.SwitchCurrentActionMap("GameOver");

        ChangeStateTo(State.WIN);
    }

    public void OnBallOutOfMap() {
        Debug.Log("GameplayManager-LoseGame");
        playerInput.SwitchCurrentActionMap("GameOver");

        ChangeStateTo(State.GAME_OVER);
    }

    public void OnInputTryAgain() {
        Debug.Log("GameplayManager-ResetGame");
        playerInput.SwitchCurrentActionMap("WaitingGameplay");

        ChangeStateTo(State.WAITING_GAMEPLAY);
    }

    public void ChangeStateTo(State state)
    {
        onStateChange?.Invoke(state);
    }

    public enum State {
        WAITING_GAMEPLAY, IN_GAME, GAME_OVER, WIN
    }
}

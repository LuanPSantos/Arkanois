using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameplayManager : MonoBehaviour
{
    public UnityEvent<State> onStateChange;
    public PlayerInput playerInput;
    private State state;
    
    void Start()
    {
        LoadGameplay();
    }

    public void LoadGameplay() {
        state = State.GAMEPLAY;

        onStateChange?.Invoke(state);
    }

    public void StartGame() {
        Debug.Log("GameplayManager-StartGame");

        playerInput.SwitchCurrentActionMap("Paddle");

        state = State.IN_GAME;

        onStateChange?.Invoke(state);
    }

    public void WinGame() {
        Debug.Log("GameplayManager-WinGame");
        playerInput.SwitchCurrentActionMap("WaitingGameplay");

        state = State.WIN;

        onStateChange?.Invoke(state);
    }

    public void LoseGame() {
        Debug.Log("GameplayManager-LoseGame");
        playerInput.SwitchCurrentActionMap("GameOver");

        state = State.GAME_OVER;

        onStateChange?.Invoke(state);
    }

    public void ResetGame() {
        Debug.Log("GameplayManager-ResetGame");
        playerInput.SwitchCurrentActionMap("WaitingGameplay");

        state = State.WAITING_GAMEPLAY;

        onStateChange?.Invoke(state);
    }

    public enum State {
        WAITING_GAMEPLAY, IN_GAME, GAME_OVER, WIN, GAMEPLAY
    }
}

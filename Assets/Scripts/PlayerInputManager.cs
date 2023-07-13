using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnGameStarted()
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void OnGameLost()
    {
        playerInput.SwitchCurrentActionMap("GameLost");
    }

    public void OnGameEnded()
    {
        playerInput.SwitchCurrentActionMap("GameEnded");
    }
}

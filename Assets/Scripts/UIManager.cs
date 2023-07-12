using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text startText;
    public TMP_Text endText;

    public void OnStateChange(GameplayManager.State state) {
        switch(state) {
            case GameplayManager.State.WAITING_GAMEPLAY:
                OnWaitingGameplay();
                break;
            case GameplayManager.State.IN_GAME:
                OnInGame();
                break;
            case GameplayManager.State.WIN:
                OnWin();
                break;
            case GameplayManager.State.GAME_OVER:
                OnGameOver();
                break;
            default:
                break;
        }
        
    }

    private void OnWaitingGameplay()
    {
        startText.gameObject.SetActive(true);
        endText.gameObject.SetActive(false);
    }

    private void OnInGame()
    {
        startText.gameObject.SetActive(false);
        endText.gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        startText.gameObject.SetActive(false);
        endText.gameObject.SetActive(true);
    }

    private void OnWin()
    {
        startText.gameObject.SetActive(false);
        endText.gameObject.SetActive(true);
    }
}

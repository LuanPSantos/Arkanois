using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text startText;
    public TMP_Text endText;

    public void OnGameStateChange(GameplayManager.State state) {
        switch(state) {
            case GameplayManager.State.WAITING_GAMEPLAY:
                startText.gameObject.SetActive(true);
                endText.gameObject.SetActive(false);
                break;
            case GameplayManager.State.IN_GAME:
                startText.gameObject.SetActive(false);
                endText.gameObject.SetActive(false);
                break;
            case GameplayManager.State.GAME_OVER:
                startText.gameObject.SetActive(false);
                endText.gameObject.SetActive(true);
                break;
            default:
                break;
        }
        
    }
}

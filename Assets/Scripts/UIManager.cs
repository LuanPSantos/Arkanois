using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text startText;
    public TMP_Text endText;

    void Start()
    {
        startText.gameObject.SetActive(true);
        endText.gameObject.SetActive(false);
    }

    public void OnGameStarted()
    {
        startText.gameObject.SetActive(false);
        endText.gameObject.SetActive(false);
    }

    public void OnGameEnded()
    {
        startText.gameObject.SetActive(false);
        endText.gameObject.SetActive(true);
    }

    public void OnGameLost()
    {
        startText.gameObject.SetActive(false);
        endText.gameObject.SetActive(true);
    }
}

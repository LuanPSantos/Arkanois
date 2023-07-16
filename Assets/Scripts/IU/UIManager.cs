using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public TMP_Text startText;
    public GameObject endView;
    public EventSystem eventSystem;
    public GameObject nextLevelButtom;

    void Start()
    {
        startText.gameObject.SetActive(true);
        endView.SetActive(false);
    }

    public void OnGameStarted()
    {
        startText.gameObject.SetActive(false);
        endView.SetActive(false);
    }

    public void OnGameEnded()
    {
        startText.gameObject.SetActive(false);
        endView.SetActive(true);
        eventSystem.firstSelectedGameObject = nextLevelButtom;
    }

    public void OnGameLost()
    {
        startText.gameObject.SetActive(false);
        endView.SetActive(true);
    }
}

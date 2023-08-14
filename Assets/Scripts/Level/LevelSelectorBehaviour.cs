using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool isLocked;
    [SerializeField]
    private string levelNumber;
    [SerializeField]
    private GameEvent selectedLevelRequested;
    [SerializeField]
    private TMPro.TextMeshProUGUI stageText;
    [SerializeField]
    private Button button;

    private void Awake()
    {
        stageText.text = levelNumber;

        isLocked = PlayerPrefs.GetInt(levelNumber, 0) == 0;

        button.interactable = !isLocked || levelNumber == "1";
    }

    public void LoadLevel()
    {
        selectedLevelRequested.Raise(levelNumber);
    }
}

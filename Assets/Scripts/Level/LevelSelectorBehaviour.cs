using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool isLocked;
    [SerializeField]
    private string levelSceneName;
    [SerializeField]
    private string levelNumber;
    [SerializeField]
    private GameEvent selectedLevelRequested;
    [SerializeField]
    private TMPro.TextMeshProUGUI stageText;

    private void Awake()
    {
        stageText.text = "Level " + levelNumber;
    }

    public void LoadLevel()
    {
        if(!isLocked)
        {
            selectedLevelRequested.Raise(levelSceneName);
        }        
    }
}

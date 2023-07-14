using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LevelManagerScriptableObject : ScriptableObject
{

    [SerializeField]
    private List<string> levelSceneNames = new List<string>();

    private int currentLevelIndex = 0;

    void Awake()
    {
        currentLevelIndex = 0;

        levelSceneNames.Add("Level1");
        levelSceneNames.Add("Level2");
    }

    public void OnGameRestarted()
    {
        SceneManager.LoadScene(levelSceneNames[currentLevelIndex], LoadSceneMode.Single);
    }

    public void OnLevelFinished()
    {
        currentLevelIndex++;
        if(currentLevelIndex < levelSceneNames.Count)
        {
            SceneManager.LoadScene(levelSceneNames[currentLevelIndex], LoadSceneMode.Single);
        }
        else
        {
            currentLevelIndex = 0;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}

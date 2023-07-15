using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LevelManagerScriptableObject : ScriptableObject
{

    [SerializeField]
    private List<string> levelSceneNames = new List<string>();

    private int currentLevelIndex;

    void Awake()
    {
        levelSceneNames.Add("Level1");
        levelSceneNames.Add("Level2");
    }

    public void LoadFistLevel()
    {
        Debug.Log("LoadFistLevel");
        currentLevelIndex = 0;
        LoadScene(levelSceneNames[currentLevelIndex]);
    }

    public void OnGameRestarted()
    {
        Debug.Log("OnGameRestarted");
        LoadScene(levelSceneNames[currentLevelIndex]);
    }

    public void OnLevelFinished()
    {
        Debug.Log("OnLevelFinished");
        currentLevelIndex++;
        if(currentLevelIndex < levelSceneNames.Count)
        {
            LoadScene(levelSceneNames[currentLevelIndex]);
        }
        else
        {
            currentLevelIndex = 0;
            LoadScene("MainMenu");
        }
    }

    private void LoadScene(string name)
    {
        Debug.Log("Loading scene "+ name);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}

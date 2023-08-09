using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LevelManagerScriptableObject : ScriptableObject
{
    [SerializeField]
    private List<string> levelSceneNames;

    private int currentLevelIndex;

    public void LoadFistLevel()
    {
        currentLevelIndex = 0;
        LoadScene(levelSceneNames[currentLevelIndex]);
    }

    public void OnLevelFinished()
    {
        currentLevelIndex++;
        if(currentLevelIndex < levelSceneNames.Count)
        {
            LoadCurrentLevel();
        }
        else
        {
            currentLevelIndex = 0;
            LoadScene("MainMenu");
        }
    }

    public void OnGameLost()
    {
        LoadCurrentLevel();
    }

    public void LoadLevelByName(object name)
    {
        var newIndex = levelSceneNames.IndexOf(name.ToString());
        if (newIndex != -1)
        {
            currentLevelIndex = levelSceneNames.IndexOf(name.ToString());
            LoadCurrentLevel();
        }
        
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadCurrentLevel()
    {
        LoadScene(levelSceneNames[currentLevelIndex]);
    }

    private void LoadScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}

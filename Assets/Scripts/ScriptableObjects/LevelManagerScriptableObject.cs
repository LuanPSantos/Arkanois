using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LevelManagerScriptableObject : ScriptableObject
{
    [SerializeField]
    private List<string> levelSceneNumbers;

    private int currentLevelIndex;

    public void OnLevelFinished()
    {
        currentLevelIndex++;

        if (currentLevelIndex < levelSceneNumbers.Count)
        {
            PlayerPrefs.SetInt(levelSceneNumbers[currentLevelIndex].ToString(), 1);
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
        var newIndex = levelSceneNumbers.IndexOf(name.ToString());
        if (newIndex != -1)
        {
            currentLevelIndex = newIndex;
            LoadCurrentLevel();
        }
        
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadCurrentLevel()
    {
        LoadScene("Level" + levelSceneNumbers[currentLevelIndex]);
    }

    private void LoadScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}

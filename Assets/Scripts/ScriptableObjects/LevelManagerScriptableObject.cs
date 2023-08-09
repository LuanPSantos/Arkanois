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
            WaitAndLoadScene();
        }
        else
        {
            currentLevelIndex = 0;
            LoadScene("MainMenu");
        }
    }

    public void OnGameLost()
    {
        WaitAndLoadScene();
    }

    public void LoadLevelByName(object name)
    {
        var newIndex = levelSceneNames.IndexOf(name.ToString());
        if (newIndex != -1)
        {
            currentLevelIndex = levelSceneNames.IndexOf(name.ToString());
            WaitAndLoadScene();
        }
        
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    private void LoadScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    private void WaitAndLoadScene()
    {
        //await Task.Delay(500);
        LoadScene(levelSceneNames[currentLevelIndex]);
    }
}

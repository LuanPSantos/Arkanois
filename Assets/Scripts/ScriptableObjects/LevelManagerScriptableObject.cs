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

    public void OnGameRestarted()
    {
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
        //await Task.Delay(500);
        LoadFistLevel();
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

using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LevelManagerScriptableObject levelManager;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameEvent gamePaused;
    [SerializeField]
    private GameEvent gameResumed;

    public void StartGame()
    {
        levelManager.LoadLevelSelection();
    }

    public void RestartGame()
    {
        levelManager.LoadCurrentLevel();
        //Time.timeScale = 1f;
    }

    public void ExitLevel()
    {
        levelManager.LoadLevelSelection();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        //Time.timeScale = 1f;
        gameResumed.Raise();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        //Time.timeScale = 0f;
        gamePaused.Raise();
    }
}

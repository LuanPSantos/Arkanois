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
        // Remover
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.SetInt("3", 0);

        levelManager.LoadLevelSelection();
    }

    public void RestartGame()
    {
        levelManager.LoadCurrentLevel();
    }

    public void ExitLevel()
    {
        levelManager.LoadLevelSelection();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameResumed.Raise();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gamePaused.Raise();
    }
}

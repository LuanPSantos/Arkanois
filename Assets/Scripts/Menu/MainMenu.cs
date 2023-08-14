using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LevelManagerScriptableObject levelManager;
    [SerializeField]
    private GameManagerScriptableObject gameManager;
    [SerializeField]
    private GameObject pauseMenu;
    

    public void StartGame()
    {
        // Remover
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.SetInt("3", 0);

        levelManager.LoadLevelSelection();
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        levelManager.LoadCurrentLevel();
    }

    public void ExitLevel()
    {
        levelManager.LoadLevelSelection();
    }

    public void ResumeGame()
    {
        gameManager.ResumeGame();
    }

    public void OnGamePaused()
    {
        pauseMenu.SetActive(true);
    }

    public void OnGameResumed()
    {
        pauseMenu.SetActive(false);
    }
}

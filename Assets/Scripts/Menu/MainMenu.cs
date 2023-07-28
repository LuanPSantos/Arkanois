using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LevelManagerScriptableObject levelManger;
    [SerializeField]
    private GameManagerScriptableObject gameManager;
    public void StartGame()
    {
        gameManager.BeforeFirstLevel();
        levelManger.LoadFistLevel();
    }
}

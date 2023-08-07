using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LevelManagerScriptableObject levelManger;
    public void StartGame()
    {
        levelManger.LoadFistLevel();
    }
}

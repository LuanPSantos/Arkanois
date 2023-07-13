using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void OnGameRestarted()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }

    public void OnGameFinished()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}

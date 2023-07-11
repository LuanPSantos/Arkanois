using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public List<LevelScriptableObject> levels = new List<LevelScriptableObject>();

    public UnityEvent<LevelScriptableObject> onLevelReady;
    
    private int currentLevelIndex = 0;
    
    public void LoadLevel() {
        var level = levels[currentLevelIndex];

        onLevelReady?.Invoke(level);
    }
}

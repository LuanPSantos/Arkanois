using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameEvent levelLoaded;
    void Start()
    {
        levelLoaded.Raise();
    }
}

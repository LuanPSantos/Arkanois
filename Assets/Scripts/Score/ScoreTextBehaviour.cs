using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextBehaviour : MonoBehaviour
{
    [SerializeField]
    private float timeToLive;

    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

}

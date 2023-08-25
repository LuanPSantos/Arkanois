using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent scoreChanged;
    private int score;
    private int comboCount;
    private int comboScore;
    void Start()
    {
        comboCount = 0;
        score = 0;
        scoreChanged.Raise(0);
    }

    public void OnBrickBroked(object brickScore)
    {
        comboCount++;
        comboScore = (int) brickScore;
        scoreChanged.Raise(score + comboScore);
    }

    public void OnEnemyDestroied(object enemyScore)
    {
        comboCount++;
        comboScore = (int) enemyScore;
        scoreChanged.Raise(score + comboScore);
    }

    public void OnHitPaddle()
    {
        comboCount = 0;
        score += comboScore;
        scoreChanged.Raise(score);
    }

    public void OnGameLost()
    {
        score += comboScore;
        scoreChanged.Raise(score);
    }

    public void OnGameEnded()
    {
        score += comboScore;
        scoreChanged.Raise(score);
    }
}

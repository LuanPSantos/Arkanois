using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent scoreChanged;
    [SerializeField]
    private GameEvent comboChanged;
    [SerializeField]
    private GameEvent comboScoreChanged;
    private int score;
    private int comboCount;
    private int comboScore;
    void Start()
    {
        score = 0;
        scoreChanged.Raise(score);

        comboCount = 0;
        comboChanged.Raise(comboCount);

        comboScore = 0;
        comboScoreChanged.Raise(comboScore);
    }

    public void OnBrickBroked(object brickScore)
    {
        comboCount++;
        comboScore += (int)brickScore;
        comboChanged.Raise(comboCount);
        comboScoreChanged.Raise(comboScore);
    }

    public void OnEnemyDestroied(object enemyScore)
    {
        comboCount++;
        comboScore += (int)enemyScore;
        comboChanged.Raise(comboCount);
        comboScoreChanged.Raise(comboScore);
    }

    public void OnHitPaddle()
    {
        CommitScore();
    }

    public void OnGameLost()
    {
        CommitScore();
    }

    public void OnGameEnded()
    {
        CommitScore();
    }

    private void CommitScore()
    {
        score += comboScore * comboCount;
        scoreChanged.Raise(score);

        comboCount = 0;
        comboChanged.Raise(comboCount);

        comboScore = 0;
        comboScoreChanged.Raise(comboScore);
    }

}

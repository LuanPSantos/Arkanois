using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent scoreChanged;
    [SerializeField]
    private GameEvent comboChanged;
    [SerializeField]
    private GameEvent comboScoreChanged;
    [SerializeField]
    private GameEvent highScoreLoaded;
    [SerializeField] 
    private GameEvent newHighScore;
    [SerializeField]
    private GameEvent finalScore;
    [SerializeField]
    private GameEvent brickBrokeProcessed;
    [SerializeField]
    private float comboDuration;

    private int score;
    private int comboCount;
    private int comboScore;
    private int highScore;
    private string sceneName;
    private float comboDurationTimer;
    void Start()
    {
        score = 0;
        scoreChanged.Raise(score);

        comboCount = 0;
        comboChanged.Raise(comboCount);

        comboScore = 0;
        comboScoreChanged.Raise(comboScore);

        sceneName = SceneManager.GetActiveScene().name;
        highScore = PlayerPrefs.GetInt(sceneName, 0);
        highScoreLoaded.Raise(highScore);
    }

    void Update()
    {
        comboDurationTimer += Time.deltaTime;
        if(comboDurationTimer > comboDuration)
        {
            comboDurationTimer = 0;
            CommitScore();
        }
    }

    public void OnBrickBroked(object brickScore)
    {
        comboCount++;
        comboScore += (int)brickScore;
        comboChanged.Raise(comboCount);
        comboScoreChanged.Raise(comboScore);
        brickBrokeProcessed.Raise();
    }

    public void OnEnemyDestroied(object enemyScore)
    {
        comboCount++;
        comboScore += (int)enemyScore;
        comboChanged.Raise(comboCount);
        comboScoreChanged.Raise(comboScore);
    }

    public void OnGameLost()
    {
        CommitScore();
    }

    public void OnGameEnded()
    {
        CommitScore();
        SetHighScore();
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

    private void SetHighScore()
    {
        var highScore = PlayerPrefs.GetInt(sceneName, 0);

        if(score > highScore)
        {
            PlayerPrefs.SetInt(sceneName, score);
            newHighScore.Raise(score);
        }
        else
        {
            finalScore.Raise(score);
        }
    }

}

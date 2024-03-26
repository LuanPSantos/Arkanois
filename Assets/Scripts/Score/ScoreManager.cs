using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
    private bool inCombo = false;

    void Start()
    {
       
        score = 0;
        scoreChanged.Raise(score);

        comboCount = 0;
        comboChanged.Raise(comboCount);

        comboScore = 0;
        comboScoreChanged.Raise(comboScore);

        sceneName = SceneManager.GetActiveScene().name;
        //PlayerPrefs.SetInt(sceneName, 0);
        highScore = PlayerPrefs.GetInt(sceneName, 0);
        highScoreLoaded.Raise(highScore);
    }

    void Update()
    {
        if(!inCombo) return;

        comboDurationTimer += Time.deltaTime;
        if(comboDurationTimer > comboDuration)
        {
            CommitScore();
        }
    }

    public void OnBrickBroked(object brickScore)
    {
        Score((int)brickScore);

  
        brickBrokeProcessed.Raise();
    }

    public void OnEnemyDestroied(object enemyScore)
    {
        Score((int)enemyScore);
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

    private void Score(int score)
    {
        inCombo = true;
        comboDurationTimer = 0;

        comboCount++;
        comboScore += score;
        comboChanged.Raise(comboCount);
        comboScoreChanged.Raise(comboScore);
    }

    private void CommitScore()
    {
        comboDurationTimer = 0;
        inCombo = false;

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

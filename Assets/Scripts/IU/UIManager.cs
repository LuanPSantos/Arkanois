using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text comboText;
    [SerializeField]
    private TMP_Text scoreComboText;
    [SerializeField]
    private TMP_Text highScoreText;

    public void OnHighScoreLoaded(object highScore)
    {
        highScoreText.text = highScore.ToString();
    }

    public void OnScoreChanged(object score)
    {
        scoreText.text = score.ToString();
    }

    public void OnScoreComboChanged(object score)
    {
        scoreComboText.text = score.ToString();
    }

    public void OnComboChanged(object combo)
    {
        comboText.text = combo.ToString();
    }

    public void OnGameEnded()
    {
        comboText.text = "0";
        scoreComboText.text = "0";
    }
}

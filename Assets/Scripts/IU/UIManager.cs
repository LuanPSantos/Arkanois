using TMPro;
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
}

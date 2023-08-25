using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    public void OnScoreChanged(object score)
    {
        scoreText.text = score.ToString();
    }
}

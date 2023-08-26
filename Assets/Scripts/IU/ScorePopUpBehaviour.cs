using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScorePopUpBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject scorePopUpPrefab;
    
    public void OnScore(object score)
    {
        var text = Instantiate(scorePopUpPrefab, transform.position, Quaternion.identity);
        text.GetComponent<TextMeshPro>().text = score.ToString();
    }
}

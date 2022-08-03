using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI ScoreUI;

    private void Awake()
    {
        ScoreUI.text = $"{GameManager.Instance.SavedScore}";
    }

    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
    }
    public void UpdateScore(int score)
    {
        ScoreUI.text = $"{score}";
    }

    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= UpdateScore;
    }
}

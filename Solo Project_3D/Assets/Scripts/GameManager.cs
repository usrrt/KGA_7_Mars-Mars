using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : SingleToneBehaviour<GameManager>
{
    public bool _isEnd;

    public ScoreText ScoreUI;

    // Á×´Â Á¶°Ç
    public float fallingSpeed;
    public float DieSpeed = 6f;

    public Vector2 LastCheckPoint;

    public int SavedScore;
    public int ScoreIncreaseAmount = 1;

    public event UnityAction<int> OnScoreChanged;

    public int CurrentScore
    {
        get { return SavedScore; }

        set 
        { 
            SavedScore = value;

            OnScoreChanged?.Invoke(SavedScore);
        }
    }

    private void Update()
    {
        if(_isEnd == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private string KeyName = "BestScore";
    public void AddScore()
    {
        CurrentScore += ScoreIncreaseAmount;
    }
   
}

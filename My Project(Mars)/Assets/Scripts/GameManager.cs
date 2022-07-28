using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleToneBehaviour<GameManager>
{
    public Vector2 LastCheckPointPos;

    public bool _isEnd = false; // 죽어버림

    
    private void Update()
    {
        if(_isEnd)
        {
            // 체크포인트장면으로 로드
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}

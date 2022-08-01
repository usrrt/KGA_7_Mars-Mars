using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleToneBehaviour<GameManager>
{
    public bool _isEnd;

    // 죽는 조건
    public float fallingSpeed;
    public float DieSpeed = 6f;

    public Vector2 LastCheckPoint;


    private void Update()
    {
        if(_isEnd == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // 코인 점수 더하는 함수
    public void AddScore()
    {
        // 점수더해서 저장해놓기
    }
}

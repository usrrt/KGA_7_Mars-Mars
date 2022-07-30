using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleToneBehaviour<GameManager>
{
    public bool _isEnd;

    // �״� ����
    public float fallingSpeed;
    public float DieSpeed = 100f;

    public Vector2 LastCheckPoint;


    private void Update()
    {
        if(_isEnd == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // ���� ���� ���ϴ� �Լ�
    public void AddScore()
    {
        // �������ؼ� �����س���
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleToneBehaviour<GameManager>
{
    public Vector2 LastCheckPointPos;

    public bool _isEnd = false; // �׾����

    
    private void Update()
    {
        if(_isEnd)
        {
            // üũ����Ʈ������� �ε�
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}

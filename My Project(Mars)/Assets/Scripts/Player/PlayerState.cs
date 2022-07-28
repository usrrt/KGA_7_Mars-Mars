using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance._isEnd = false;
    }

    public void Die()
    {
        GameManager.Instance._isEnd = true;
        Destroy(gameObject);
    }
}

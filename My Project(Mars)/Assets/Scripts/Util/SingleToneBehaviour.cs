using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleToneBehaviour<T> : MonoBehaviour where T : MonoBehaviour // T는 monoBehaviour를 상속받는것들로 이루어져있음
{
    private static T m_Instance;

    public static T Instance
    {
        get
        {
            if(m_Instance == null)
            {
                m_Instance = FindObjectOfType<T>();
                DontDestroyOnLoad(m_Instance.gameObject);
            }

            return m_Instance;
        }
    }

    private void Awake()
    {
        if(m_Instance != null)
        {
            if(m_Instance != this)
            {
                Destroy(gameObject);
            }

            return;
        }
        else
        {
            m_Instance = GetComponent<T>();
            DontDestroyOnLoad (gameObject);
        }
    }
}

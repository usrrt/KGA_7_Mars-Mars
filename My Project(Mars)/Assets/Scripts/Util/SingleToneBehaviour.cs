using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleToneBehaviour<T> : MonoBehaviour where T : MonoBehaviour // T�� monoBehaviour�� ��ӹ޴°͵�� �̷��������
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

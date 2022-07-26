using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool _isStepped = false;
    public GameObject[] _platform;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        _isStepped = false;
    }
}

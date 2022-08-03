using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public Color startColor = Color.green;
    public Color endColor = Color.red;

    Renderer _render;
    private AlarmTrigger _trigger;

    private void Awake()
    {
        _render = GetComponent<Renderer>();
        _trigger = GetComponentInChildren<AlarmTrigger>();
    }

    private void Update()
    {
        _render.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * _trigger.Blink, 1));
    }
}

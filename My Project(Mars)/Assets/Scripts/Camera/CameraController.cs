using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraMode
{
    DefaultView,

}
public class CameraController : MonoBehaviour
{
    CameraMode _mode = CameraMode.DefaultView;
    private CameraTrigger _trigger;
    private CameraSpeedTrigger _speed;



    // 플레이어와 유지할 vector값
    [SerializeField]
    private Vector3 _delta;

    [SerializeField]
    private GameObject _player;

    //public float cameraSpeed;

    public float CameraSize;
    //public bool isCameraAngleOut;

    private void Awake()
    {
        _trigger = GetComponentInChildren<CameraTrigger>();
        _speed = GetComponentInChildren<CameraSpeedTrigger>();

    }

    private void Start()
    {
        _trigger.IsCameraMove = false;

    }

    private void Update()
    {

        if (_trigger.IsCameraMove)
        {
            if (_mode == CameraMode.DefaultView)
            {
                float xposMoveAmount = _player.transform.position.x + _delta.x;
                //Debug.Log(xposMoveAmount);

                transform.position = Vector3.Lerp(transform.position, new Vector3(xposMoveAmount, _delta.y, -10f), Time.deltaTime * _speed.CameraSpeed);
            }

        }

    }

}

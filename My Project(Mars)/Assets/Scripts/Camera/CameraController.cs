using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraMode
{
    QuaterView,

}
public class CameraController : MonoBehaviour
{
    CameraMode _mode = CameraMode.QuaterView;
    private CameraTrigger _trigger;

    // 플레이어와 유지할 vector값
    [SerializeField]
    private Vector3 _delta;

    [SerializeField]
    private GameObject _player;

    public float cameraSpeed;
    public float xPos1;
    public float xPos2;
    //public bool isCameraAngleOut;

    private void Awake()
    {
        _trigger = GetComponentInChildren<CameraTrigger>();
    }

    private void Start()
    {
        _trigger.isCameraAngleOut = false;
    }

    private void Update()
    {
        if (_trigger.isCameraAngleOut)
        {
            if (_mode == CameraMode.QuaterView)
            {
                xPos1 = transform.position.x;
                xPos2 = _player.transform.position.x;
                float xposMoveAmount = _player.transform.position.x + _delta.x;
                Debug.Log(xposMoveAmount);

                transform.position = Vector3.Lerp(transform.position, new Vector3(xposMoveAmount, _delta.y, -10f), Time.deltaTime * cameraSpeed);
            }

        }



    }

}

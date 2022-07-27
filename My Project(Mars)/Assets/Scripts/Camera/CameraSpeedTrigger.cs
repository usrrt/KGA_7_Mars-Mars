using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeedTrigger : MonoBehaviour
{
    public float CameraSpeed;

    private void Awake()
    {
        CameraSpeed = 0.2f;
    }

    // 카메라 시야밖으로 나가면 카메라 속도가 빨라지게한다
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraSpeed = 3f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraSpeed = 0.2f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float yPos;
    private void Update()
    {
        Vector3 newCamPos = new Vector3(target.position.x, GameManager.Instance.LastCheckPoint.y - yPos, transform.position.z);
        gameObject.transform.position = newCamPos;
    }
}

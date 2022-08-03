using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public float Blink;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(GameManager.Instance.fallingSpeed >= GameManager.Instance.DieSpeed)
            {
                //Debug.Log("danger");
                Blink = 5f;
            }
            else
            {
                //Debug.Log("safe");
                Blink = 0f;
            }
        }
    }
}

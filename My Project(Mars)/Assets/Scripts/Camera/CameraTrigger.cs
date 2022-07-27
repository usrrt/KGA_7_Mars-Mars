using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public bool IsCameraMove;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsCameraMove = true;
            //Debug.Log("exit");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsCameraMove = false;
            //Debug.Log("enter");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public bool isCameraAngleOut;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isCameraAngleOut = true;
            Debug.Log("exit");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isCameraAngleOut = false;
            Debug.Log("enter");
        }
    }


}

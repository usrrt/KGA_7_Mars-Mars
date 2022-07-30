using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string MoveAxisName = "Horizontal";

    public float MoveDirection { get; private set; }
    public bool CanJump { get; private set; }
    public bool BoostUp { get; private set; }

    private void Update()
    {
        MoveDirection = Input.GetAxis(MoveAxisName);
        CanJump = Input.GetKeyDown(KeyCode.Space);
        BoostUp = Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow);
    }
}

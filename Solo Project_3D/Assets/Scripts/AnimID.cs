using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAnimID
{
    public static readonly int Start = Animator.StringToHash("JumpStart");
    public static readonly int Loop = Animator.StringToHash("Jump_loop");
    public static readonly int End = Animator.StringToHash("JumpEnd");
    public static readonly int Flip = Animator.StringToHash("Flip");
}


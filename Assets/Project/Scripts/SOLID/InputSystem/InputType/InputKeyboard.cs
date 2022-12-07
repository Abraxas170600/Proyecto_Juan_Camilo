using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboard : InputHandler
{
    public override float GetAxisHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public override float GetAxisVertical()
    {
        return Input.GetAxis("Vertical");
    }

    public override bool GetJump()
    {
        return Input.GetButtonDown("Jump");
    }

    public override bool GetJetpackJump()
    {
        return Input.GetKey(KeyCode.E);
    }

}

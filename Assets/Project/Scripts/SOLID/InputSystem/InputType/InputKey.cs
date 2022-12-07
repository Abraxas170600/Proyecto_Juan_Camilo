using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKey : InputHandler
{
    public KeyCode _keyLeft = KeyCode.A;
    public KeyCode _keyRight = KeyCode.D;
    public KeyCode _keyDown = KeyCode.S;
    public KeyCode _keyUp = KeyCode.W;
    public KeyCode _keyJump = KeyCode.Space;
    public KeyCode _keyJetpack = KeyCode.E;

    public override float GetAxisHorizontal()
    {
        if (Input.GetKey(_keyLeft))
            return -1;
        if (Input.GetKey(_keyRight))
            return 1;
        return 0;
    }

    public override float GetAxisVertical()
    {
        if (Input.GetKey(_keyDown))
            return -1;
        if (Input.GetKey(_keyUp))
            return 1;
        return 0;
    }

    public override bool GetJump()
    {
        if (Input.GetKeyDown(_keyJump))
            return true;
        if (Input.GetKeyUp(_keyJump))
            return false;
        return false;
    }

    public override bool GetJetpackJump()
    {
        if (Input.GetKey(_keyJetpack))
            return true;
        if (Input.GetKeyUp(_keyJetpack))
            return false;
        return false;
    }

}

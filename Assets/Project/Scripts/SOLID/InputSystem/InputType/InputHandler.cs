using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour
{
    public abstract float GetAxisHorizontal();
    public abstract float GetAxisVertical();
    public abstract bool GetJump();
    public abstract bool GetJetpackJump();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSettings : MonoBehaviour
{
    public CinemachineFreeLook _freeLookCamera;
    public void StateCamera(bool state)
    {
        if (state)
        {
            _freeLookCamera.m_YAxis.m_MaxSpeed = 0;
            _freeLookCamera.m_XAxis.m_MaxSpeed = 0;
            state = false;
        }
        else
        {
            _freeLookCamera.m_YAxis.m_MaxSpeed = 4;
            _freeLookCamera.m_XAxis.m_MaxSpeed = 450;
            state = true;
        }

    }
}

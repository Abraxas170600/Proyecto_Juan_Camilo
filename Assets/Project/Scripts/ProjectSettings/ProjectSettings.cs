using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectSettings : MonoBehaviour
{
    //public CameraSettings _cameraSettings;
    public static ProjectSettings _projectSettings;
    private void Awake()
    {
        _projectSettings = this;
        Application.targetFrameRate = 60;
        StateGame(1);
    }
    public void StateGame(int state)
    {
        if (state <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            //_cameraSettings.StateCamera(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            //_cameraSettings.StateCamera(false);
        }
    }
    public void QuitGame() => Application.Quit();
}

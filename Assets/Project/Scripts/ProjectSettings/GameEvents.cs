using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents _gameEvents;
    private void Awake()
    {
        _gameEvents = this;
    }
    public event Action ScoreDetected;
    public void Detected()
    {
        if(ScoreDetected != null)
            ScoreDetected();
    }
    public event Action AddPoint;
    public void Add()
    {
        if (AddPoint != null)
            AddPoint();
    }
    public event Action AddScoreText;
    public void AddOnText()
    {
        if (AddScoreText != null)
            AddScoreText();
    }
    public event Action SoundAction;
    public void DialogueSound()
    {
        if (SoundAction != null)
            SoundAction();
    }
}

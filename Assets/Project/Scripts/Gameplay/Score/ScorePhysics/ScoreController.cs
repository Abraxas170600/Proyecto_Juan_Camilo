using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public ScoreManager _scoreManager;
    private void Start()
    {
        GameEvents._gameEvents.ScoreDetected += PlayerInteraction;
    }
    public void PlayerInteraction()=> _scoreManager._scoreImpulse.Impulse(_scoreManager._rigidbody);
    private void OnDestroy()
    {
        GameEvents._gameEvents.ScoreDetected -= PlayerInteraction;
    }
}

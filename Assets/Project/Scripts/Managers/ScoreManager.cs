using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Database _scoreDatabase;
    public ScoreImpulse _scoreImpulse { get; private set; }
    public ScoreDetector _scoreDetector { get; private set; }
    public Rigidbody _rigidbody { get; private set; }
    private void Start()
    {
        GetComponent();
        _scoreImpulse.Impulse(_rigidbody);
    }
    public void GetComponent()
    {
        _scoreImpulse = GetComponent<ScoreImpulse>();
        _scoreDetector = GetComponent<ScoreDetector>();
        _rigidbody = GetComponent<Rigidbody>();
    }
}

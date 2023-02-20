using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Database _scoreDatabase;
    public DataStorageObject _dataStorageObject;
    public ScoreImpulse _scoreImpulse { get; private set; }
    public ScoreDetector _scoreDetector { get; private set; }
    public ScoreFunctions _scoreFunctions { get; private set; }
    public Rigidbody _rigidbody { get; private set; }
    private void Start()
    {
        GetComponent();
        GameEvents._gameEvents.AddPoint += AddScoreFunctions;   
        Initialize();
    }
    public void Initialize()
    {
        _scoreImpulse.Impulse(_rigidbody);
    }
    public void GetComponent()
    {
        _scoreImpulse = GetComponent<ScoreImpulse>();
        _scoreDetector = GetComponent<ScoreDetector>();
        _scoreFunctions = GetComponent<ScoreFunctions>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void AddScoreFunctions()
    {
        _scoreFunctions.AddScore(_scoreDatabase, _dataStorageObject._dataStorage, _dataStorageObject._dataStorage._checker);
    }
    private void OnDestroy()
    {
        GameEvents._gameEvents.AddPoint -= AddScoreFunctions;
    }
}

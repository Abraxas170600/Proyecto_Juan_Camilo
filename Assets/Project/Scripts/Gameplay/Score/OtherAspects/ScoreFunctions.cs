using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFunctions : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private DialogueUI _dialogueUI;
    private int _checker;
    private void Start()
    {
        GameEvents._gameEvents.AddPoint += AddScore;
        CheckScore();
    }
    public void AddScore() 
    {
        _playerManager._dataStorageObject._dataStorage._currentScore += _playerManager._playerDatabase._score[_playerManager._playerDatabase._player[_playerManager.indexPlayer]._playerData._id]._scoreData._scoreAmount;
        CheckScore();
    } 
    public void CheckScore()
    {
        for (int i = 0; i < _playerManager._playerDatabase._dialogue._dialogueData._sentences.Length; i++)
        {
            if(_playerManager._dataStorageObject._dataStorage._currentScore >= _playerManager._playerDatabase._dialogue._dialogueData._sentences[i]._requierementScore && _checker == i)
            {
                GameEvents._gameEvents.DialogueSound();
                _dialogueUI.ShowText(i);
                _checker++;
            }
        }
    }
    private void OnDestroy()
    {
        GameEvents._gameEvents.AddPoint -= AddScore;
    }
}

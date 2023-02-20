using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Database _dialogueDatabase;
    public DataStorageObject _dataStorageObject;
    public DialogueUI _dialogueUI { get; private set; }
    public DialogueFunctions _dialogueFunctions { get; private set; }
    private void Start()
    {
        GetComponent();
        GameEvents._gameEvents.checkCurrentDialogue += CheckDialogue;
        Initialize();
    }
    public void Initialize()
    {
        _dialogueFunctions.AddDialogueToDictionary(_dialogueDatabase, _dataStorageObject._dataStorage);
        for (int i = 0; i < _dialogueDatabase._dialogue._dialogueData._sentences.Length; i++)
        {
            if (_dataStorageObject._dataStorage._checker == i && _dataStorageObject._dataStorage._checker == 0)
                GameEvents._gameEvents.DialogueSound();

            if (_dataStorageObject._dataStorage._checker == i && _dataStorageObject._dataStorage._checker != 0)
                GameEvents._gameEvents.InitSound();

            //if (_dataStorageObject._dataStorage._checker != i)
            //    GameEvents._gameEvents.InitSound();
        }
        GameEvents._gameEvents.Check();
    }
    public void GetComponent()
    {
        _dialogueUI = GetComponent<DialogueUI>();
        _dialogueFunctions = GetComponent<DialogueFunctions>();
    }
    public void CheckDialogue()
    {
        for (int i = 0; i < _dialogueDatabase._dialogue._dialogueData._sentences.Length; i++)
        {
            if (_dataStorageObject._dataStorage._currentScore >= _dialogueDatabase._dialogue._dialogueData._sentences[i]._requierementScore && _dataStorageObject._dataStorage._checker == i)
            {
                _dialogueUI.ShowText(i);
                _dialogueFunctions.RemoveDialogueToDictionary(_dialogueDatabase, _dataStorageObject._dataStorage, i);
                _dataStorageObject._dataStorage._checker++;
            }
        }
    }
    private void OnDestroy()
    {
        GameEvents._gameEvents.checkCurrentDialogue -= CheckDialogue;
    }
}

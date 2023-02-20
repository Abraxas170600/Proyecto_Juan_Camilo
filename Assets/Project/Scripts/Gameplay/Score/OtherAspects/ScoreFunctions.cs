using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFunctions : MonoBehaviour
{
    public void AddScore(Database database, DataStorage dataStorage, int checker) 
    {
        dataStorage._currentScore += database._score[database._player[dataStorage._indexPlayer]._playerData._id]._scoreData._scoreAmount;
        CheckScore(database, dataStorage, checker);
    } 
    public void CheckScore(Database database, DataStorage dataStorage, int checker)
    {
        for (int i = 0; i < database._dialogue._dialogueData._sentences.Length; i++)
        {
            if(dataStorage._currentScore >= database._dialogue._dialogueData._sentences[i]._requierementScore && checker == i)
            {
                GameEvents._gameEvents.DialogueSound();
                GameEvents._gameEvents.Check();
                checker++;
            }
        }
    }
}

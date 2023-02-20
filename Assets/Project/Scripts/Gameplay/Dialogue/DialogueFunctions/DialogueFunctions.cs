using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFunctions : MonoBehaviour
{
    public void InitCurrentDialogues(DataStorage dataStorage)
    {
        if (dataStorage._currentDialogues == null)
            dataStorage._currentDialogues = new Dictionary<string, int>();
    }
    public void AddDialogueToDictionary(Database database, DataStorage dataStorage)
    {
        InitCurrentDialogues(dataStorage);

        for (int i = 0; i < database._dialogue._dialogueData._sentences.Length; i++)
        {
            if(!dataStorage._currentDialogues.ContainsKey(database._dialogue._dialogueData._sentences[i]._sentence) && dataStorage._checker < i)
                dataStorage._currentDialogues.Add(database._dialogue._dialogueData._sentences[i]._sentence, i);
        }
    }
    public void RemoveDialogueToDictionary(Database database, DataStorage dataStorage, int index) => dataStorage._currentDialogues.Remove(database._dialogue._dialogueData._sentences[index]._sentence);
}

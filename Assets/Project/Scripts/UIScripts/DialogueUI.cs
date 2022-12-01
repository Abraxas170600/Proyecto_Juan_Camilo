using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class DialogueUI : MonoBehaviour
{
    public DialogueManager _dialogueManager;

    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private Animator _dialogueAnimation;
    [SerializeField] private GameObject _dialogueObject;
    public void ShowText(int index)
    {
        if (index <= _dialogueManager._dialogueDatabase._dialogue._dialogueData._sentences.Length + 1)
        {
            _dialogueText.text = _dialogueManager._dialogueDatabase._dialogue._dialogueData._sentences[index]._sentence;
            TextFunction();
        }
    }
    public async void TextFunction()
    {
        await Task.Delay(System.TimeSpan.FromSeconds(3));
        _dialogueObject.SetActive(true);
        await Task.Delay(System.TimeSpan.FromSeconds(8));
        _dialogueAnimation.Play("DialogueText_Animation 0");
        await Task.Delay(System.TimeSpan.FromSeconds(3));
        _dialogueObject.SetActive(false);
    }
}

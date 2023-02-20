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
            StartCoroutine(TextFunction());
        }
    }
    public IEnumerator TextFunction()
    {
        yield return new WaitForSeconds(3f);
        _dialogueObject.SetActive(true);
        yield return new WaitForSeconds(8f);
        _dialogueAnimation.Play("DialogueText_Animation 0");
        yield return new WaitForSeconds(3f);
        _dialogueObject.SetActive(false);
    }
    private void OnApplicationQuit() => StopAllCoroutines();
}

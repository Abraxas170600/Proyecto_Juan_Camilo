using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueData
{
    public Sentence[] _sentences;
}
[System.Serializable]
public class Sentence
{
    public int _requierementScore;
    [TextArea(3, 10)]
    public string _sentence;
}

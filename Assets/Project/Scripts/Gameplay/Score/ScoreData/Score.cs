using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Score Type", menuName = "Score Type")]
public class Score : ScriptableObject
{
    public ScoreData _scoreData;
}

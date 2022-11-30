using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ScoreData
{
    public int _scoreAmount;
    public ScoreType _scoreType;
    public enum ScoreType{ Normal, Heavy, Light }
}

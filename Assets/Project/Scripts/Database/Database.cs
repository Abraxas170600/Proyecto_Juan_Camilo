using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "Database")]
public class Database : ScriptableObject
{
    public Player[] _player;
    public Score[] _score;
    public Dialogue _dialogue;
}

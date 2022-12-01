using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreImpulse : MonoBehaviour
{
    public void Impulse(Rigidbody rigidbody) => rigidbody.AddForce(new Vector3(Random.Range(3, 6), Random.Range(4, 8), Random.Range(3, 6)), ForceMode.Impulse);
}

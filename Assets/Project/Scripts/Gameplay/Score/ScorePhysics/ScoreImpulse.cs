using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreImpulse : MonoBehaviour
{
    public void Impulse(Rigidbody rigidbody) => rigidbody.AddForce(new Vector3(Random.Range(2, 4), Random.Range(3, 7), Random.Range(2, 4)), ForceMode.Impulse);
}

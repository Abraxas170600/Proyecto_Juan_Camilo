using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour
{
    private Collider _collider;
    public void UpdatePhysics(PhysicMaterial physicMaterial, Rigidbody _rigidbody, float _mass)
    {
        _collider = GetComponent<Collider>();
        _collider.material = physicMaterial;
        _rigidbody.mass = _mass;
    }
}

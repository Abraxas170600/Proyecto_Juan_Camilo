using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string _name;
    public int _id;
    public BasicMovement _basicMovement;
    public AdvancedMovement _advancedMovement;
    public OtherAspects _otherAspects;
}
[System.Serializable]
public class BasicMovement
{
    public float _movementVelocity;
    public float _jumpHeight;
}
[System.Serializable]
public class AdvancedMovement
{
    public float _jetpackRechargeRate;
    public float _fuelAmount;
    public float _maxFuel;
    public float _boostStrength;
}
[System.Serializable]
public class OtherAspects
{
    public Material _material;
    public PhysicMaterial _physicMaterial;
    public float _playerMass;
}

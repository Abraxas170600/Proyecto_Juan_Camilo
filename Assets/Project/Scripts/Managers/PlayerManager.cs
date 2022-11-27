using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player _player;
    public PlayerMovement _playerMovement { get; private set; }
    public PlayerSkin _playerSkin { get; private set; }
    public PlayerDetector _playerDetector { get; private set; }
    public JetpackJump _jetpackJump { get; private set; }
    public Rigidbody _rb { get; private set; }

    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        GetComponent();
        _playerSkin.UpdateMaterial(_player._playerData._otherAspects._material);
        _jetpackJump.Initialize(_player._playerData._advancedMovement._fuelAmount);
    }
    public void GetComponent()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerSkin = GetComponent<PlayerSkin>();
        _playerDetector = GetComponent<PlayerDetector>();
        _jetpackJump = GetComponent<JetpackJump>();
    }
}

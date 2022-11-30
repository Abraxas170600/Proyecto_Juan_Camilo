using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Database _playerDatabase;
    public PlayerMovement _playerMovement { get; private set; }
    public PlayerSkin _playerSkin { get; private set; }
    public PlayerPhysic _playerPhysic { get; private set; }
    public PlayerDetector _playerDetector { get; private set; }
    public JetpackJump _jetpackJump { get; private set; }
    public Rigidbody _rb { get; private set; }
    public int indexPlayer { get; private set; }
    public int _currentScore;

    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        GetComponent();
        UpdatePlayer(indexPlayer);
    }
    public void GetComponent()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerSkin = GetComponent<PlayerSkin>();
        _playerPhysic = GetComponent<PlayerPhysic>();
        _playerDetector = GetComponent<PlayerDetector>();
        _jetpackJump = GetComponent<JetpackJump>();
    }
    public void UpdatePlayer(int index)
    {
        indexPlayer = index;
        _playerSkin.UpdateMaterial(_playerDatabase._player[index]._playerData._otherAspects._material);
        _playerPhysic.UpdatePhysics(_playerDatabase._player[index]._playerData._otherAspects._physicMaterial, _rb, _playerDatabase._player[index]._playerData._otherAspects._playerMass);
        _jetpackJump.Initialize(_playerDatabase._player[index]._playerData._advancedMovement._fuelAmount);
    }
}

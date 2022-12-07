using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public Database _playerDatabase;
    public PlayerInput _playerInput { get; private set; }
    public PlayerSkin _playerSkin { get; private set; }
    public PlayerPhysic _playerPhysic { get; private set; }
    public PlayerDetector _playerDetector { get; private set; }
    public Rigidbody _rb { get; private set; }
    public Transform _camPosition;
    public int indexPlayer { get; private set; }
    public int _currentScore;
    public UnityEvent<float, Database, int> OnUpdateFuel;

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
        _playerInput = GetComponent<PlayerInput>();
        _playerSkin = GetComponent<PlayerSkin>();
        _playerPhysic = GetComponent<PlayerPhysic>();
        _playerDetector = GetComponent<PlayerDetector>();
    }
    public void Update()
    {
        UpdatePlayerActions();
        OnUpdateFuel.Invoke(_playerInput.fuel, _playerDatabase, indexPlayer);
    }
    public void UpdatePlayerActions()
    {
        _playerInput.Movement(_playerDatabase._player[indexPlayer]._playerData._basicMovement._movementVelocity, _rb, _camPosition);
        _playerInput.Jump(_playerDetector._isGrounded, _playerDatabase._player[indexPlayer]._playerData._basicMovement._jumpHeight, _rb);
        _playerInput.Jetpack(_playerDetector._isGrounded, _rb, _playerDatabase._player[indexPlayer]._playerData._advancedMovement._jetpackRechargeRate, _playerDatabase._player[indexPlayer]._playerData._advancedMovement._fuelAmount, _playerDatabase._player[indexPlayer]._playerData._advancedMovement._maxFuel, _playerDatabase._player[indexPlayer]._playerData._advancedMovement._boostStrength);
    }
    public void UpdatePlayer(int index)
    {
        indexPlayer = index;
        _playerSkin.UpdateMaterial(_playerDatabase._player[index]._playerData._otherAspects._material);
        _playerPhysic.UpdatePhysics(_playerDatabase._player[index]._playerData._otherAspects._physicMaterial, _rb, _playerDatabase._player[index]._playerData._otherAspects._playerMass);
        _playerInput.Initialize(_playerDatabase._player[index]._playerData._advancedMovement._fuelAmount);
    }
}

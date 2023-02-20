using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public Database _playerDatabase;
    public DataStorageObject _dataStorageObject;
    public PlayerInput _playerInput { get; private set; }
    public PlayerSkin _playerSkin { get; private set; }
    public PlayerPhysic _playerPhysic { get; private set; }
    public PlayerDetector _playerDetector { get; private set; }
    public Rigidbody _rb { get; private set; }
    public Transform _camPosition;
    //public int indexPlayer { get; private set; }

    public UnityEvent<float, Database, int> OnUpdateFuel;
    public UnityEvent<int> OnUpdateScoreText;
    private void Start()
    {
        GetComponent();
        GameEvents._gameEvents.AddScoreText += UpdateScore;
        Initialize();
    }
    public void Initialize()
    {
        UpdatePlayer(_dataStorageObject._dataStorage._indexPlayer);
        UpdateScore();
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
        OnUpdateFuel.Invoke(_playerInput.fuel, _playerDatabase, _dataStorageObject._dataStorage._indexPlayer);
    }
    public void UpdatePlayerActions()
    {
        _playerInput.Movement(_playerDatabase._player[_dataStorageObject._dataStorage._indexPlayer]._playerData._basicMovement._movementVelocity, _rb, _camPosition);
        _playerInput.Jump(_playerDetector._isGrounded, _playerDatabase._player[_dataStorageObject._dataStorage._indexPlayer]._playerData._basicMovement._jumpHeight, _rb);
        _playerInput.Jetpack(_playerDetector._isGrounded, _rb, _playerDatabase._player[_dataStorageObject._dataStorage._indexPlayer]._playerData._advancedMovement._jetpackRechargeRate, _playerDatabase._player[_dataStorageObject._dataStorage._indexPlayer]._playerData._advancedMovement._fuelAmount, _playerDatabase._player[_dataStorageObject._dataStorage._indexPlayer]._playerData._advancedMovement._maxFuel, _playerDatabase._player[_dataStorageObject._dataStorage._indexPlayer]._playerData._advancedMovement._boostStrength);
    }
    public void UpdatePlayer(int index)
    {
        _dataStorageObject._dataStorage._indexPlayer = index;
        _playerSkin.UpdateMaterial(_playerDatabase._player[index]._playerData._otherAspects._material);
        _playerPhysic.UpdatePhysics(_playerDatabase._player[index]._playerData._otherAspects._physicMaterial, _rb, _playerDatabase._player[index]._playerData._otherAspects._playerMass);
        _playerInput.Initialize(_playerDatabase._player[index]._playerData._advancedMovement._fuelAmount);
    }
    public void UpdateScore() => OnUpdateScoreText.Invoke(_dataStorageObject._dataStorage._currentScore);
    private void OnDestroy() => GameEvents._gameEvents.AddScoreText -= UpdateScore;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _camPosition;
    public PlayerManager _playerManager;

    private float _horizontal;
    private float _vertical;
    private bool _isJump = false;
    private bool _jetpack = false;
    public void ProcessInputs()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _isJump = Input.GetButtonDown("Jump");
        _jetpack = Input.GetKey(KeyCode.E);
    }
    private void Update()
    {
        ProcessInputs();
        _playerManager._playerMovement.Jump(_playerManager._playerDetector._isGrounded, _playerManager._playerDatabase._player[_playerManager.indexPlayer]._playerData._basicMovement._jumpHeight, _playerManager._rb, _isJump);
        _playerManager._jetpackJump.Jetpack(_playerManager._playerDetector._isGrounded, _playerManager._rb, _playerManager._playerDatabase._player[_playerManager.indexPlayer]._playerData._advancedMovement._jetpackRechargeRate, _playerManager._playerDatabase._player[_playerManager.indexPlayer]._playerData._advancedMovement._fuelAmount, _playerManager._playerDatabase._player[_playerManager.indexPlayer]._playerData._advancedMovement._maxFuel, _playerManager._playerDatabase._player[_playerManager.indexPlayer]._playerData._advancedMovement._boostStrength, _jetpack);
    }
    private void FixedUpdate()
    {
        _playerManager._playerMovement.UpdateMovement(_playerManager._playerDatabase._player[_playerManager.indexPlayer]._playerData._basicMovement._movementVelocity, _playerManager._rb, _camPosition, _horizontal, _vertical);
    }
}

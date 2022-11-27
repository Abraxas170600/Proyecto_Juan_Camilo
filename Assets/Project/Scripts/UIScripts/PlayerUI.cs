using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerManager _playerManager;

    public Image _fuelBar;
    private void Update()
    {
        UpdateFuelBar();
    }
    public void UpdateFuelBar()
    {
        _fuelBar.fillAmount = _playerManager._jetpackJump.fuel / _playerManager._player._playerData._advancedMovement._maxFuel;
    }
}

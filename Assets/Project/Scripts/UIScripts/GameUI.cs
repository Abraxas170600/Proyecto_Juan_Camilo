using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public PlayerManager _playerManager;

    public GameObject _MenuPanel;
    public GameObject _characterPanel;
    public TMP_Text _scoreText;
    public Image _fuelBar;

    public static bool _menuPanelActive;
    public static bool _characterPanelActive;

    private void Start()
    {
        GameEvents._gameEvents.AddScoreText += UpdateScoreText;
    }
    private void Update()
    {
        UpdateFuelBar();
        MenuPanel();
    }
    public void UpdateFuelBar()
    {
        _fuelBar.fillAmount = _playerManager._jetpackJump.fuel / _playerManager._playerDatabase._player[_playerManager.indexPlayer]._playerData._advancedMovement._maxFuel;
    }
    public void UpdateScoreText()
    {
        _scoreText.text = $"{_playerManager._currentScore}";
    }
    public void MenuPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_menuPanelActive)
            {
                ProjectSettings._projectSettings.StateGame(1);
                _MenuPanel.SetActive(false);
                _characterPanel.SetActive(false);
                _menuPanelActive = false;
                _characterPanelActive = false;
            }
            else
            {
                ProjectSettings._projectSettings.StateGame(0);
                _MenuPanel.SetActive(true);
                _menuPanelActive = true;
            }
        }
    }
    public void CharacterPanel()
    {
        if (_characterPanelActive)
        {
            _characterPanel.SetActive(false);
            _characterPanelActive = false;
        }
        else
        {
            _characterPanel.SetActive(true);
            _characterPanelActive = true;
        }
    }
    private void OnDestroy()
    {
        GameEvents._gameEvents.AddScoreText -= UpdateScoreText;
    }

}

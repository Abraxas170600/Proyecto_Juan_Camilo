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
    public GameObject _optionsPanel;
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
        //UpdateFuelBar();
        MenuPanel();
    }
    public void UpdateFuelBar(float fuel, Database database, int index)
    {
        _fuelBar.fillAmount = fuel / database._player[index]._playerData._advancedMovement._maxFuel;
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
                Time.timeScale = 1;
                _MenuPanel.SetActive(false);
                _characterPanel.SetActive(false);
                _optionsPanel.SetActive(false);
                _menuPanelActive = false;
                _characterPanelActive = false;
            }
            else
            {
                ProjectSettings._projectSettings.StateGame(0);
                Time.timeScale = 0;
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
    public void OptionsPanel(int panelActive)
    {
        if (panelActive == 0)
        {
            _optionsPanel.SetActive(true);
            //Time.timeScale = 0;
        }
        else if (panelActive == 1)
        {
            _optionsPanel.SetActive(false);
            //Time.timeScale = 1;
        }
    }
    public void QuitButton()
    {
        ProjectSettings._projectSettings.QuitGame();
    }
    private void OnDestroy()
    {
        GameEvents._gameEvents.AddScoreText -= UpdateScoreText;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public DataStorageObject _dataStorageObject;

    public GameObject _MenuPanel;
    public GameObject _characterPanel;
    public GameObject _optionsPanel;
    public TMP_Text _scoreText;
    public Image _fuelBar;

    public static bool _menuPanelActive;
    public static bool _characterPanelActive;
    private void Update() => MenuPanel();
    public void UpdateFuelBar(float fuel, Database database, int index) => _fuelBar.fillAmount = fuel / database._player[index]._playerData._advancedMovement._maxFuel;
    public void UpdateScoreText(int currentScore)
    {
        currentScore = _dataStorageObject._dataStorage._currentScore;
        _scoreText.text = $"{currentScore}";
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
            _optionsPanel.SetActive(true);
        else if (panelActive == 1)
            _optionsPanel.SetActive(false);
    }
    public void QuitButton()
    {
        ProjectSettings._projectSettings.QuitGame();
    }
}

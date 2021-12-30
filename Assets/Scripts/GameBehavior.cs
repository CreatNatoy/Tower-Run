using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerBehavior))]
public class GameBehavior : MonoBehaviour
{
    [SerializeField] private Menu _menuCanvas;
    [SerializeField] private StarLevel _starLevel;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject _panelFinish;
    private PlayerBehavior _playerBehavior;

    private void Start()
    {
        _playerBehavior = GetComponent<PlayerBehavior>(); 
    }

    public void GameOver()
    {
        ActivePanel(_panelGameOver);
    }

    public void FinishGame(int sizeTower)
    {
        ActivePanel(_panelFinish);
        _starLevel.AddStarLevel(sizeTower);
        SaveLevel();
        SaveCoin(); 
    }


    private void ActivePanel(GameObject panel)
    {
        _menuCanvas.activatePanel(panel);
        int stopTime = 0; 
        _menuCanvas.TimeGame(stopTime);
    }

    private void SaveLevel()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            if (PlayerPrefs.GetInt("Level") <= SceneManager.GetActiveScene().buildIndex)
                PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }

    private void SaveCoin()
    {
        if (PlayerPrefs.HasKey("Coin"))
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + _playerBehavior.CounterCoiuns);
        else
            PlayerPrefs.SetInt("Coin", _playerBehavior.CounterCoiuns); 
    }
}

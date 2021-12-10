using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] private Menu _menuCanvas;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject _panelFinish;

    public void GameOver()
    {
        ActivePanel(_panelGameOver);
    }

    public void FinishGame()
    {
        ActivePanel(_panelFinish);
    }


    private void ActivePanel(GameObject panel)
    {
        _menuCanvas.activatePanel(panel);
        int stopTime = 0; 
        _menuCanvas.TimeGame(stopTime);
    }
}

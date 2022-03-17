using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] private Menu _menuCanvas;
    [SerializeField] private StarLevel _starLevel;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject _panelFinish;
    [SerializeField] private CounterCoin _counterCoin;
    [SerializeField] private Save _save;

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
        panel.SetActive(true);
        int stopTime = 0;
        _menuCanvas.TimeGame(stopTime);
    }

    private void SaveLevel()
    {
        if (_save.GetKeyLevel() <= SceneManager.GetActiveScene().buildIndex)
            _save.SetKeyLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SaveCoin()
    {
        _save.SetKeyCoin(_save.GetKeyCoin() + _counterCoin.CounterCoiuns); 
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Save _savePlayerSkin; 

    public void Exit()
    {
        Application.Quit(); 
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene); 
    }

    public void ReplayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void TimeGame (int time)
    {
        Time.timeScale = time; 
    }

    public void ChooseSkinPlayer(int index)
    {
        _savePlayerSkin.SetKeyPlayer(index); 
    }
}

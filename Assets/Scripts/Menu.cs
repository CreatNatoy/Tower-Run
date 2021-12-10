using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Menu : MonoBehaviour
{
    
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

    public void activatePanel(GameObject panel)
    {
        panel.SetActive(true); 
    }

    public void OffPanel(GameObject panel)
    {
        panel.SetActive(false); 
    }

    public void TimeGame (int time)
    {
        Time.timeScale = time; 
    }

    public void DeleteKeys()
    {
        PlayerPrefs.DeleteAll(); 
    }
}

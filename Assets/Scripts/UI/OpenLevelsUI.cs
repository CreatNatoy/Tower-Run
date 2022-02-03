using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLevelsUI : MonoBehaviour
{
    [SerializeField] private Button[] _buttonsLevels;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);

        OpenLevelsButtons(); 
    }

    private void OpenLevelsButtons()
    {
        for (int i = 0; i < _buttonsLevels.Length; i++)
        {
            if (i < PlayerPrefs.GetInt("Level"))
            {
                _buttonsLevels[i].interactable = true;
                _buttonsLevels[i].gameObject.GetComponent<StarLevelUI>().ChangeSpriteStar(i + 1); 
            //    Debug.Log("Open button: " + i);
            }
            else
            {
                _buttonsLevels[i].interactable = false;
            //    Debug.Log("Close button: " + i);
            }
        }
    }
}

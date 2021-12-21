using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarLevelUI : MonoBehaviour
{
    [SerializeField] private Image[] _startsLevel;
    [SerializeField] private Sprite _fullStar; 

    public void ChangeSpriteStar(int size)
    {
        if (!PlayerPrefs.HasKey("StarLevel" + size))
            PlayerPrefs.GetInt("StarLevel" + size, 0);
        else    
            for (int i = 0; i < PlayerPrefs.GetInt("StarLevel" + size); i++)
                _startsLevel[i].sprite = _fullStar;

        Debug.Log("Star level: " + PlayerPrefs.GetInt("StarLevel" + size));
    }
}

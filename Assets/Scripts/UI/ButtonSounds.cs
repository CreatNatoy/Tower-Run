using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Image _sound; 

    private void Start()
    {
            PlayerPrefs.SetInt("Sound", 1);
             _sound.sprite = _soundOn;
    }

    public void ChangeSound()
    {
        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            PlayerPrefs.SetInt("Sound", 0);
            _sound.sprite = _soundOff;
        }
        else if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 1);
            _sound.sprite = _soundOn;
        }

    }
}

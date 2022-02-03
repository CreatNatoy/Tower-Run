using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuySkin : MonoBehaviour
{
   [SerializeField] private GameObject _buttonBuySkin;
   [SerializeField] private int _index;

    private void Start()
    {
        Debug.Log("Skin " + _index);
        if (!PlayerPrefs.HasKey("ButtonBuySkin" +_index))
        {
            PlayerPrefs.SetInt("ButtonBuySkin" + _index, 0);
            Debug.Log("You not buy skin " + _index);
        }
        else if(PlayerPrefs.GetInt("ButtonBuySkin" + _index) == 1)
        {
            _buttonBuySkin.SetActive(false);
            Debug.Log("You buy skin " + _index);
        }
    }

    public void BuySkin (int cost)
    {
        if(PlayerPrefs.GetInt("Coin") > cost)
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - cost);
            PlayerPrefs.SetInt("ButtonBuySkin" + _index, 1);
            _buttonBuySkin.SetActive(false);
            Debug.Log("Buy skin");
        }
        else
        {
            Debug.Log("Don't many");
        }
    }

}

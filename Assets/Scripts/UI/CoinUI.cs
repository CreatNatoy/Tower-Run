using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Text _textCoin;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Coin"))
            PlayerPrefs.SetInt("Coin", 0);

        _textCoin.text = PlayerPrefs.GetInt("Coin").ToString("D3");
    }
}

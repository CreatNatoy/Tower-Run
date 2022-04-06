using UnityEngine;
using UnityEngine.UI;

public class CounterCoin : MonoBehaviour
{
    [SerializeField] private Text _textCoins;
    [SerializeField] private SoundEffects _soundEffects;
    private int _counterCoins;

    public int CounterCoiuns => _counterCoins; 

    public void AddCoin(CoinRotate coin)
    {
        coin.gameObject.SetActive(false);
        _counterCoins++;
        _textCoins.text = _counterCoins.ToString("D3");
        _soundEffects.AddCoinSound();
    }
}

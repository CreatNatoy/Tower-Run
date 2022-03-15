using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Text _textCoin;
    [SerializeField] private Save _saveCoin; 

    private void Start()
    {
        UpdateTextCoin();
    }

    public void UpdateTextCoin()
    {
        _textCoin.text = _saveCoin.GetKeyCoin().ToString("D3");
    }
}

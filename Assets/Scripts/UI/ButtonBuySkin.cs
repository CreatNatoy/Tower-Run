using UnityEngine;

public class ButtonBuySkin : MonoBehaviour
{
    [SerializeField] private GameObject _buttonBuySkin;
    [SerializeField] private int _index;
    [SerializeField] private CoinUI _cointUI;
    [SerializeField] private Save _saveSkin; 

    private void Start()
    {
        _saveSkin.CheckKeyButtonBuySkin(_index); 

        if (_saveSkin.GetKeyButtonBuySkin(_index) == 1)
            _buttonBuySkin.SetActive(false);
    }

    public void BuySkin(int cost)
    {
        if (_saveSkin.GetKeyCoin() > cost)
        {
            int coins = _saveSkin.GetKeyCoin() - cost; 
            _saveSkin.SetKeyCoin(coins);
            _saveSkin.SetKeyButtonBuySkin(_index); 
            _cointUI.UpdateTextCoin();
            _buttonBuySkin.SetActive(false);
        }
    }
}

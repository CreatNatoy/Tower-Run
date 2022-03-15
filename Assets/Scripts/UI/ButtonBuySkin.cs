using UnityEngine;

public class ButtonBuySkin : MonoBehaviour
{
    [SerializeField] private GameObject _buttonBuySkin;
    [SerializeField] private int _index;
    [SerializeField] private CoinUI _cointUI;
    [SerializeField] private Save _saveSkin; 

    private void Start()
    {
        _saveSkin.CheckKeySkin(_index); 

        if (_saveSkin.GetKeySkin(_index) == 1)
            _buttonBuySkin.SetActive(false);
    }

    public void BuySkin(int cost)
    {
        if (_saveSkin.GetKeyCoin() > cost)
        {
            _saveSkin.SetKeyCoin(_saveSkin.GetKeyCoin() - cost);
            _saveSkin.SetKeyCoin(_index); 
            _cointUI.UpdateTextCoin();
            _buttonBuySkin.SetActive(false);
        }
    }
}

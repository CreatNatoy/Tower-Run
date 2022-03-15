using UnityEngine;

public class Save : MonoBehaviour
{
    private void Awake()
    {
        CheckKeysSave();
    }

    private void CheckKeysSave()
    {
        CheckKeyCoin();
        CheckKeySound();
    }

    public int GetKeyCoin()
    {
        return PlayerPrefs.GetInt("Coin");
    }

    public void SetKeyCoin(int coin)
    {
        PlayerPrefs.SetInt("Coin", coin); 
    }    

    private void CheckKeyCoin()
    {
        if (!PlayerPrefs.HasKey("Coin"))
            PlayerPrefs.SetInt("Coin", 0);
    }

    public int GetKeyStarLevel(int index)
    {
        CheckKeyStarLevel(index);
        return PlayerPrefs.GetInt("StarLevel" + index); 
    }

    public void CheckKeyStarLevel(int index)
    {
        if (!PlayerPrefs.HasKey("StarLevel" + index))
            PlayerPrefs.GetInt("StarLevel" + index, 0);
    }

    public int GetKeyLevel()
    {
        CheckKeyLevel();
        return PlayerPrefs.GetInt("Level");
    }

    public void CheckKeyLevel()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
    }

    public void SetKeyPlayer(int index)
    {
        PlayerPrefs.SetInt("Player", index);
    }

    public int GetKeySound()
    {
        return PlayerPrefs.GetInt("Sound");
    }

    public void SetKeySound(int value)
    {
        PlayerPrefs.SetInt("Sound", value);
    }

    public void CheckKeySound()
    {
        if (!PlayerPrefs.HasKey("Sound"))
            PlayerPrefs.SetInt("Sound", 1);
    }

    public int GetKeySkin(int index)
    {
        return PlayerPrefs.GetInt("ButtonBuySkin" + index);
    }

    public void SetKeySkin(int index)
    {
        PlayerPrefs.SetInt("ButtonBuySkin" + index, 1);
    }

    public void CheckKeySkin(int index)
    {
        if (!PlayerPrefs.HasKey("ButtonBuySkin" + index))
            PlayerPrefs.SetInt("ButtonBuySkin" + index, 0);
    }

    public void DeleteKeys()
    {
        PlayerPrefs.DeleteAll();
    }
}

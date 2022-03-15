using UnityEngine;

public class Save : MonoBehaviour
{
    private void Awake()
    {
        CheckKeysSave();
    }

    public int GetKeyCoin()
    {
        return PlayerPrefs.GetInt("Coin");
    }

    public int GetKeyLevel()
    {
        CheckKeyLevel();
        return PlayerPrefs.GetInt("Level");
    }

    public int GetKeyStarLevel(int index)
    {
        CheckKeyStarLevel(index);
        return PlayerPrefs.GetInt("StarLevel" + index); 
    }

    private void CheckKeysSave()
    {
        CheckKeyCoin();
    }

    private void CheckKeyCoin()
    {
        if (!PlayerPrefs.HasKey("Coin"))
            PlayerPrefs.SetInt("Coin", 0);
    }

    public void CheckKeyLevel()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
    }

    public void CheckKeyStarLevel(int index)
    {
        if (!PlayerPrefs.HasKey("StarLevel" + index))
            PlayerPrefs.GetInt("StarLevel" + index, 0);
    }
}

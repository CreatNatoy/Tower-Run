using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarLevel : MonoBehaviour
{
    [SerializeField] private Image[] _starsLevel;
    [SerializeField] private Sprite _fullStar;
    [SerializeField] private int _starSizeOne;
    [SerializeField] private int _starSizeTwo;
    [SerializeField] private int _starSizeThree; 

    public void AddStarLevel(int sizeTower)
    {
        Debug.Log("Size Human Tower: " + sizeTower);
        if (_starSizeThree <= sizeTower)
        {
            Debug.Log("Star: " + 3);
            int _addThreeStar = 3;
            ChangeSpriteStar(_addThreeStar); 
        }
        else if (_starSizeThree > sizeTower && _starSizeTwo <= sizeTower)
        {
            Debug.Log("Star: " + 2);
            int _addTwoStar = 2;
            ChangeSpriteStar(_addTwoStar);
        }
        else if (_starSizeTwo > sizeTower  && _starSizeOne <= sizeTower)
        {
            Debug.Log("Star: " + 1);
            int _addOneStar = 1;
            ChangeSpriteStar(_addOneStar);
        }

    }

    private void ChangeSpriteStar(int size)
    {
        for(int i = 0; i < size; i++)
        {
            _starsLevel[i].sprite = _fullStar;
            Debug.Log("Add star: " + i); 
        }

        if (PlayerPrefs.HasKey("StarLevel" + SceneManager.GetActiveScene().buildIndex))
        {
            if (PlayerPrefs.GetInt("StarLevel" + SceneManager.GetActiveScene().buildIndex) < size)
                PlayerPrefs.SetInt("StarLevel" + SceneManager.GetActiveScene().buildIndex , size); 
        }
        else
            PlayerPrefs.SetInt("StarLevel" + SceneManager.GetActiveScene().buildIndex, size);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarLevel : MonoBehaviour
{
    [SerializeField] private Image[] _starsLevel;
    [SerializeField] private Sprite _fullStar;
    [SerializeField] private Save _save; 
    [SerializeField] private int _starSizeOne;
    [SerializeField] private int _starSizeTwo;
    [SerializeField] private int _starSizeThree; 

    public void AddStarLevel(int sizeTower)
    {
        if (_starSizeThree <= sizeTower)
        {
            int _addThreeStar = 3;
            ChangeSpriteStar(_addThreeStar); 
        }
        else if (_starSizeThree > sizeTower && _starSizeTwo <= sizeTower)
        {
            int _addTwoStar = 2;
            ChangeSpriteStar(_addTwoStar);
        }
        else if (_starSizeTwo > sizeTower  && _starSizeOne <= sizeTower)
        {
            int _addOneStar = 1;
            ChangeSpriteStar(_addOneStar);
        }
    }

    private void ChangeSpriteStar(int size)
    {
        for(int i = 0; i < size; i++)
        {
            _starsLevel[i].sprite = _fullStar;
        }

        int level = SceneManager.GetActiveScene().buildIndex;

        _save.CheckKeyStarLevel(level);
        
        if(_save.GetKeyStarLevel(level) < size)
            _save.SetKeyStarLevel(level, size);
    }
}

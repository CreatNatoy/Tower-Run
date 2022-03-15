using UnityEngine;
using UnityEngine.UI;

public class StarLevelUI : MonoBehaviour
{
    [SerializeField] private Image[] _startsLevel;
    [SerializeField] private Sprite _fullStar;
    [SerializeField] private Save _saveStar;

    public void ChangeSpriteStar(int index)
    {
       int openStarFull = _saveStar.GetKeyStarLevel(index);
        for (int i = 0; i < openStarFull; i++)
            _startsLevel[i].sprite = _fullStar;
    }
}

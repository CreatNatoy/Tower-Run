using UnityEngine;
using UnityEngine.UI;

public class OpenLevelsUI : MonoBehaviour
{
    [SerializeField] private Button[] _buttonsLevels;
    [SerializeField] private Save _saveLevel; 

    private void Start()
    {
        OpenLevelsButtons(); 
    }

    private void OpenLevelsButtons()
    {
        int openLevels = _saveLevel.GetKeyLevel(); 
        for (int i = 0; i < _buttonsLevels.Length; i++)
        {
            if (i < openLevels)
            {
                _buttonsLevels[i].interactable = true;
                _buttonsLevels[i].gameObject.GetComponent<StarLevelUI>().ChangeSpriteStar(i + 1); 
            }
            else
            {
                _buttonsLevels[i].interactable = false;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Image _sound;
    [SerializeField] private Save _saveSound;

    private int OnSound = 1;
    private int OffSound = 0;
    private bool menuSound = true; 

    private void Start()
    {
        _saveSound.SetKeySound(OnSound); 
             _sound.sprite = _soundOn;
    }

    public void ChangeSound()
    {
        if(_saveSound.GetKeySound() == 1)
        {
            _saveSound.SetKeySound(OffSound);
            _sound.sprite = _soundOff;
        }
        else if (_saveSound.GetKeySound() == 0)
        {
            _saveSound.SetKeySound(OnSound);
            _sound.sprite = _soundOn;
        }

    }

    public void MenuSound(AudioSource audio)
    {
        if(menuSound)
        {
            menuSound = false;
            audio.enabled = false;
        }
        else
        {
            menuSound = true;
            audio.enabled = true;
        }
    }
}

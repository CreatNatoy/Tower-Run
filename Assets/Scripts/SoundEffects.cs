using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceEffect;
    [SerializeField] private AudioSource _audioSource; 
    [SerializeField] private AudioClip _jumpUp, _jumpDown, _jumpStrong, _addCoin, _deleteHuman;
    [SerializeField] private Save _saveSound; 

    private void Start()
    {
        SettingSound();
    }

    private void SettingSound()
    {
        if (_saveSound.GetKeySound() == 1)
        {
            OffOrOnSound(0.5f, 1); 
        }
        else
        {
            OffOrOnSound(0, 0);
        }
    }

    private void OffOrOnSound(float volumeSource, float volumeEffect)
    {
        _audioSource.volume = volumeSource;
        _audioSourceEffect.volume = volumeEffect;
    }

    public void JumpUpSound()
    {
        _audioSourceEffect.PlayOneShot(_jumpUp); 
    }

    public void JumpDownSound()
    {
        _audioSourceEffect.PlayOneShot(_jumpDown); 
    }

    public void JumpStrongSound()
    {
        _audioSourceEffect.PlayOneShot(_jumpStrong); 
    }

    public void AddCoinSound()
    {
        _audioSourceEffect.PlayOneShot(_addCoin); 
    }

    public void DeleteHumanSound()
    {
        _audioSourceEffect.PlayOneShot(_deleteHuman); 
    }
}

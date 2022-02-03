using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceEffect;
    [SerializeField] private AudioSource _audioSource; 
    [SerializeField] private AudioClip _jumpUp, _jumpDown, _jumpStrong, _addCoin, _deleteHuman;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
                SettingSound(true);
            else
                SettingSound(false); 
        }

    }

    private void SettingSound(bool state)
    {
        _audioSourceEffect.enabled = state;
        _audioSource.enabled = state;
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

    public void DeleteHuman()
    {
        _audioSourceEffect.PlayOneShot(_deleteHuman); 
    }
}

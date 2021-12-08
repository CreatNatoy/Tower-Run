using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpUp, _jumpDown, _jumpStrong; 

    public void JumpUpSound()
    {
        _audioSource.PlayOneShot(_jumpUp); 
    }

    public void JumpDownSound()
    {
        _audioSource.PlayOneShot(_jumpDown); 
    }

    public void JumpStrongSound()
    {
        _audioSource.PlayOneShot(_jumpStrong); 
    }
}

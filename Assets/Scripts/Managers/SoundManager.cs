using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour, IInitialize
{
    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private AudioSource _buttonClickSound;

    public void Init()
    {
        _backgroundSound?.Play();
    }

    public void PLayButtonClickSound()
    {
        _buttonClickSound?.Play();
    }

    public void MuteUnMuteAllSounds()
    {
        AudioListener.volume = AudioListener.volume == 1 ? 0 : 1;
    }

    public void OnOffBackgroundMusic()
    {
        _backgroundSound.mute = !_backgroundSound.mute;
    }    
}

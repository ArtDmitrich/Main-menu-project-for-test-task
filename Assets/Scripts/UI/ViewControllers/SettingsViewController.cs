using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettingsViewController : MonoBehaviour
{
    public UnityEvent StateBackgroundMusicChanged;
    public UnityEvent StateAllSoundChanged;

    public void ChangeStateBackGroundMusic()
    {
        StateBackgroundMusicChanged?.Invoke();
    }

    public void ChangeStateAllSound()
    {
        StateAllSoundChanged?.Invoke();
    }
}

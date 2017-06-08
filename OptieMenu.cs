using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* er zijn sliders in de optie menu deze kan je bewegen om de audio zachter/harder te zetten 
 * waarden worden doorgegeven aan sliders */
#endregion

public class OptieMenu : MonoBehaviour
{
    public Slider[] volumeSliders;

    void Start()
    {
        volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders[2].value = AudioManager.instance.sfxVolumePercent;
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetsfxVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.sfx);
    }	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetMusicVol : MonoBehaviour
{
    //Set audio mixer
    public AudioMixer mixer;

    //Get exposed mixer volume and set level from slider
    public void SetMusicLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}

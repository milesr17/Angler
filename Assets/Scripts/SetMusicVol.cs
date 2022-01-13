using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetMusicVol : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMusicLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}

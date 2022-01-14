using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetSFXVol : MonoBehaviour
{
    //Set audio mixer
    public AudioMixer mixer;

    //Get exposed mixer volume and set level from slider
    public void SetSFXLevel(float sliderValue)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlaying : MonoBehaviour
{
    //Declare audio sources
    public AudioSource jump;
    public AudioSource dmg;
    public AudioSource kill;
    public AudioSource pickup;
    public AudioSource success;
    public AudioSource fail;

    //Declare instance
    public static SoundPlaying sfxInstance;

    //Initialise instance before game starts
    private void Awake()
    {
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
    
    //Play audio functions
    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayDmg()
    {
        dmg.Play();
    }

    public void PlayKill()
    {
        kill.Play();
    }

    public void PlayPickup()
    {
        pickup.Play();
    }
    public void PlaySuccess()
    {
        success.Play();
    }

    public void PlayFail()
    {
        fail.Play();
    }
}

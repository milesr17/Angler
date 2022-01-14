using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    private static MusicChange instance = null;
    public static MusicChange Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if(instance == null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(instance);
    }
}

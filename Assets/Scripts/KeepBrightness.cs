using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepBrightness : MonoBehaviour
{
    //Keep brightness image persistent
    public Image currentImage;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

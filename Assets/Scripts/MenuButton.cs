using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    //Load menu scene
    public void menuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}

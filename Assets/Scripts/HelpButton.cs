using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour
{
    //Load help menu
    public void helpScene()
    {
        SceneManager.LoadScene("Help");
    }
}

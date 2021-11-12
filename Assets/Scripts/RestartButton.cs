using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
   //Reload level scene
    public void restartScene()
    {
        SceneManager.LoadScene("PlayerTest");
    }
}

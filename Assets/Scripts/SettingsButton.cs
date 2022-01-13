using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public float waitTime;
    public Animator musicAnim;
    public Animator sceneAnim;

    //Load settings menu
    public void settingsScene()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        musicAnim.SetTrigger("musicFadeOut");
        sceneAnim.SetTrigger("sceneFadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Settings");
    }
}

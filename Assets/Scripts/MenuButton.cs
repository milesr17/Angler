using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public float waitTime;
    public Animator musicAnim;
    public Animator sceneAnim;

    //Load menu scene
    public void menuScene()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        musicAnim.SetTrigger("musicFadeOut");
        sceneAnim.SetTrigger("sceneFadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Menu");
    }
}

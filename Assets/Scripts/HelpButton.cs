using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour
{
    public float waitTime;
    public Animator musicAnim;
    public Animator sceneAnim;

    //Load help menu
    public void helpScene()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        musicAnim.SetTrigger("musicFadeOut");
        sceneAnim.SetTrigger("sceneFadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Help");
    }
}

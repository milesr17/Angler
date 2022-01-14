using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEasy : MonoBehaviour
{
    //Anim variables
    public float waitTime;
    public Animator musicAnim;
    public Animator sceneAnim;

    //Load level scene
    public void levelScene()
    {
        //Call Coroutine Method
        StartCoroutine(SceneChange());
    }

    //Trigger Anim, Load Scene after delay
    IEnumerator SceneChange()
    {
        musicAnim.SetTrigger("musicFadeOut");
        sceneAnim.SetTrigger("sceneFadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("PlayerTest");
    }
}

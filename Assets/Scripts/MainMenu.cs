using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public float waitTime;
    public Animator musicAnim;
    public Animator sceneAnim;

    //Load game scene
    public void PlayGame ()
    {
        StartCoroutine(SceneChange());
    }
    
    IEnumerator SceneChange()
    {
        musicAnim.SetTrigger("musicFadeOut");
        sceneAnim.SetTrigger("sceneFadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
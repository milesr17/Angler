using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
<<<<<<< Updated upstream
    //Load menu scene
    public void menuScene()
    {
=======
    //Anim variables
    public float waitTime;
    public Animator musicAnim;
    public Animator sceneAnim;

    //Load menu scene
    public void menuScene()
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
>>>>>>> Stashed changes
        SceneManager.LoadScene("Menu");
    }
}

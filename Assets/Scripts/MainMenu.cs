using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    //Load game scene
    public void PlayGame ()
    {
<<<<<<< Updated upstream
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
=======
        StartCoroutine(SceneChange());
    }
    
    IEnumerator SceneChange()
    {
        musicAnim.SetTrigger("musicFadeOut");
        sceneAnim.SetTrigger("sceneFadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("LevelSelect");
>>>>>>> Stashed changes
    }
    
}

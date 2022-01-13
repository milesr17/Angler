using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBrightness : MonoBehaviour
{
    public GameObject currentGameObject;
    public float alpha = 0.5f;
    //Get the current material
    private Image currentImage;

    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = gameObject;
        currentImage = currentGameObject.GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        //ChangeAlpha(currentGameObject.GetComponent<Renderer>().material, alpha);
    }

    void ChangeAlpha(Image img, float alphaValue)
    {
        Color oldColor = img.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
        img.color = newColor;
    }

    public void ChangeAlphaOnSlider(Slider slider)
    {
        ChangeAlpha(currentImage, slider.value);
    }
}

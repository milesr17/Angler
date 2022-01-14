using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}

    //RestartUI
    public GameObject youDiedText;
    public GameObject restartButton;
    public GameObject player;

    private void Awake()
    {
        currentHealth = startingHealth;
        //Disable death UI
        youDiedText.SetActive(false);
        restartButton.SetActive(false);

    }
    public void TakeDamage (float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        SoundPlaying.sfxInstance.PlayDmg();

        if (currentHealth > 0)
        {

        }
        else
        {
            youDiedText.SetActive(true);
            restartButton.SetActive(true);
            player.SetActive(false);
            SoundPlaying.sfxInstance.PlayFail();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }

}
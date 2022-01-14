using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //Kill enemy
    public void Die()
    {
        Debug.Log("Enemy died");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.SetActive(false);
        SoundPlaying.sfxInstance.PlayKill();
    }
}

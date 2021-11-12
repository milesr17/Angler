using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAIDetect : MonoBehaviour
{
    
    [field: SerializeField]
    public bool PlayerInRange { get; private set; } //Player flag
    public Transform Player { get; private set; } //Set player when collided

    //Set player tag
    [SerializeField]
    private string detectTag = "Player";

    //Detect player when they enter box collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectTag))
        {
            //Has detected player out of all collisions
            PlayerInRange = true;
            Player = collision.gameObject.transform;
            //Enable the ranged attack
            gameObject.GetComponentInParent<RangedEnemyAttack>().enabled = true;
        }
    }
    //Undetect player when they leave the box collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(detectTag))
        {
            //Has detected the player left the collider
            PlayerInRange = false;
            Player = null;
            //Disable the ranged attack
            gameObject.GetComponentInParent<RangedEnemyAttack>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAIDetect : MonoBehaviour
{
    [field: SerializeField]
    public bool PlayerInRange { get; private set; }
    public Transform Player { get; private set; }

    [SerializeField]
    private string detectTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectTag))
        {
            PlayerInRange = true;
            Player = collision.gameObject.transform;
            gameObject.GetComponentInParent<RangedEnemyAttack>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(detectTag))
        {
            PlayerInRange = false;
            Player = null;
            gameObject.GetComponentInParent<RangedEnemyAttack>().enabled = false;
        }
    }
}

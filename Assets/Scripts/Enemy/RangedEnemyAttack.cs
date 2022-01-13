using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{

    public GameObject Orb;

    private Transform _tf;

    public float fullAttackWait = 2.0f;
    public float fullOrbDelay = 0.2f;
    private float attackWait;
    private float orbDelay;
    private double orbCount = 0;

    void Start()
    {
        attackWait = fullAttackWait;
        orbDelay = fullOrbDelay;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(attackWait + " " + orbDelay + " " + orbCount);
        // this logic creates a 3 orb attack every some ticks, where each orb fires per some ticks (some is changeable)
        if (attackWait < 0)
        {
            if (orbDelay < 0)
            {
                Instantiate(Orb, GetComponent<Transform>());
                // the Orb itself's script controls movement towards the player, we just spawn it in here
                orbDelay = fullOrbDelay;
                orbCount++;
            }
            else if(orbCount <= 2)
            {
                orbDelay -= 0.01f;
            }
            else if (orbCount > 2)
            {
                attackWait = fullAttackWait;
                orbCount = 0;
            }
        }
        else
        {
            attackWait -= 0.01f;
        }
    }
}

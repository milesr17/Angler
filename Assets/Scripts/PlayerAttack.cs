using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO
 * Apply Damage
 * Add Enemy Layer to inspector
 */
public class PlayerAttack : MonoBehaviour
{
    //Cooldown variables
    private float meleeAtkCooldown;
    public float startMeleeAtkCooldown;
    private float rangedAtkCooldown;
    public float startRangedAtkCooldown;

    //Attack range variables
    public Transform meleeAtkPos;
    public float meleeAtkRange;
    public LayerMask enemyLayer;

    public GameObject harpoon;
    public Transform rangedAtkPos;
    public float throwSpeed;

    void Update()
    {
        if(meleeAtkCooldown <= 0)
        {
            //Melee attack
            if(Input.GetKey(KeyCode.Space))
            {
                //Check enemies in range
                Collider2D[] targetableEnemies = Physics2D.OverlapCircleAll(meleeAtkPos.position, meleeAtkRange, enemyLayer);
                for(int i = 0; i < targetableEnemies.Length; i++)
                {
                    //TODO Apply Damage
                }
            }
            //Reset cooldown
            meleeAtkCooldown = startMeleeAtkCooldown;
        }
        else
        {
            //Decrease cooldown
            meleeAtkCooldown -= Time.deltaTime;
        }

        if(rangedAtkCooldown <= 0)
        {
            //Ranged attack
            if(Input.GetKeyDown(KeyCode.E))
            {
                //Spawn projectile
                GameObject newHarpoon = Instantiate(harpoon, rangedAtkPos.position, Quaternion.Euler(0, 0, 3));
                newHarpoon.GetComponent<Rigidbody2D>().velocity = transform.right * throwSpeed;
                //Reset cooldown
                rangedAtkCooldown = startRangedAtkCooldown;
            }
        }
        else
        {
            //Decrease cooldown
            rangedAtkCooldown -= Time.deltaTime;
        }
    }

    //Attack range scene visual
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeAtkPos.position, meleeAtkRange);
    }
}

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
    //private float harpoonCooldown;
    //public float startHarpoonCooldown;

    //Attack range variables
    public Transform meleeAtkPos;
    public float meleeAtkRangeX;
    public float meleeAtkRangeY;
    public LayerMask enemyLayer;


    void Update()
    {
        if(meleeAtkCooldown <= 0)
        {
            //Melee attack
            if(Input.GetKey(KeyCode.Space))
            {
                //Play attack animation
                //this.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                //Check enemies in range
                Collider2D[] targetableEnemies = Physics2D.OverlapBoxAll(meleeAtkPos.position, new Vector2(meleeAtkRangeX, meleeAtkRangeY), 0, enemyLayer);
                Debug.Log("Melee attack!");
                for (int i = 0; i < targetableEnemies.Length; i++)
                {
                    Destroy(targetableEnemies[i]);
                }
            }
            //Reset cooldown
            meleeAtkCooldown = startMeleeAtkCooldown;
            //harpoonCooldown = startHarpoonCooldown;
            //this.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            //Decrease cooldown
            meleeAtkCooldown -= Time.deltaTime;
            //harpoonCooldown -= Time.deltaTime;
        }



                //newHarpoon.GetComponent<Rigidbody2D>().velocity = transform.right * throwSpeed;
                //Reset cooldown
                //rangedAtkCooldown = startRangedAtkCooldown;
    }

    //Attack range scene visual
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(meleeAtkPos.position, new Vector3(meleeAtkRangeX, meleeAtkRangeY, 1));
    }
}

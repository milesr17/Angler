using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //Declare attack position, enemy layer, set range;
    public Transform meleeAtkPos;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        //Melee if space is hit
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Melee();
        }
    }

    //Melee attack
    void Melee()
    {
        //Set array for enemy collisions
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleeAtkPos.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            //Run kill function for enemies
            enemy.GetComponent<EnemyDeath>().Die();
        }
    }

    //Show attack range in scene
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(meleeAtkPos.position, attackRange);
    }
}

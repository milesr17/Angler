using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform meleeAtkPos;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Melee();
        }
    }

    void Melee()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleeAtkPos.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehaviour>().Die();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(meleeAtkPos.position, attackRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public Animator animator;
    public LayerMask enemyLayers;
    public int lightdamage=20;
    public int heavydamage=45;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            L_Attack();
        }
         if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            H_Attack();
        }
    }
    void L_Attack()
    {
        animator.SetTrigger("Attack_L");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(lightdamage);
        }
    }
    void H_Attack()
    {
        animator.SetTrigger("Attack_H");
              Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit a Heavy" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(heavydamage);
        }
    }
    void OnDrawGizmosSelected() 
    {
        if(AttackPoint== null)
         return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);     
    }
} 

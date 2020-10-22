using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask DamageableLayerMask;
    public float Damage;
    public float AttackRange;
    private Animator _animObject;




    private void Start()
    {
        _animObject = GetComponent<Animator>();
    }


    public void _Attack()
    {
        _animObject.SetTrigger("Attack");
    }


    public void TakeAttack()
    {
        var currentHealth = transform.GetComponent<HealthScript>();
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, DamageableLayerMask);
        if (enemies.Length != 0 && currentHealth.СurrentHealth() > 0)
        {
            for (var i = 0; i < enemies.Length; i++)
            {
               var em = enemies[i].GetComponent<HealthScript>();
               em.TakeDamege(Damage);
            }
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }



}

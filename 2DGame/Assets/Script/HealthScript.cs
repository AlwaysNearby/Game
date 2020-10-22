using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [SerializeField] private float Health;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamege(float damage)
    {
        Health -= damage;
        if (Health <= 0)
            Die();
        else
            anim.SetTrigger("Hit");
    }

    public float СurrentHealth()
    {
        return Health;
    }
    private void Die()
    {
        Destroy(gameObject);
    }



}

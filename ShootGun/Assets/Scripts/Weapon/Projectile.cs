using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    
    
    public Vector3 Direction { private get; set; } = Vector3.zero;


    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position  +  Direction * _speed, Time.deltaTime * _speed);
    }


    private void DamageAt(IDamageable target)
    {
        target.Damage(_damage);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }


    public void SetVelocity(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
        Rotate(direction);
    }


    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Decrease(_damage);
        }
        Destroy(this.gameObject);
    }


    private void Rotate(Vector3 direction)
    {
        transform.LookAt(direction);
    }
    
    
    
}

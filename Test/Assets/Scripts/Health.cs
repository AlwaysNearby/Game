using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;


    private float _maxHealth;
    private bool _isDead;
    
    public event Action OnDeath;
    public event Action<float, float> OnHit;


    private void Start()
    {
        _maxHealth = _health;
        _isDead = false;
    }


    public void Decrease(float damage)
    {
        if (_isDead)
        {
            return;
        }
        
        _health -= damage;
        
        OnHit?.Invoke(_health, _maxHealth);
        
        if (_health <= 0)
        {
            OnDeath?.Invoke();
            _isDead = true;
        }
    }
    
}

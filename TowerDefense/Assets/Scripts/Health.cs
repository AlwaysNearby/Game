using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    
    [SerializeField] private float _startHealth;
    [SerializeField] private float _step;
    
    
    
    
    private float _health;
    
    
    public event Action OnDeath;
    public event Action OnHit;

    public float Max
    {
        get => _startHealth;
        private set { ; }
    }

    public float Current
    {
        get => _health;
        private set { ; }
    }

    private void Start()
    {
        var wave = FindObjectOfType<Wave>().GetComponent<Wave>().Current;
        _health = _startHealth + _step * (wave - 1);
    }


    public void Decrease(float damage)
    {
        _health -= damage;
        OnHit?.Invoke();
        if (_health <= 0)
        {
            OnDeath?.Invoke();
        }
    }



    
    
}

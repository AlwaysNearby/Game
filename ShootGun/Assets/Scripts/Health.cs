using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action OnDeath;
    
    [SerializeField] private float _max;

    private float _current;

    private void Start()
    {
        _current = _max;
    }

    public void Damage(float amountOfHarm)
    {
        _current -= amountOfHarm;
        if (_current <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpot : MonoBehaviour
{
    
    
    
    private int _numberOfEnemies;
    private Action OnDeleteFromSpot;
    private Enemy[] _allEnemies;
    private ShootingHandler _shootingHandler;

    private void Awake()
    {
        _allEnemies = GetComponentsInChildren<Enemy>();
        _shootingHandler = FindObjectOfType<ShootingHandler>().GetComponent<ShootingHandler>();
    }

    private void Start()
    {
        _numberOfEnemies = _allEnemies.Length;
    }


    private void OnEnable()
    {
        foreach (var enemy in _allEnemies)
        {
            enemy.GetComponent<Health>().OnDeath += RemoveFromSpot;
        }

        OnDeleteFromSpot += _shootingHandler.ReduceTargets;
    }


    private void OnDisable()
    {
        foreach (var enemy in _allEnemies)
        {
            enemy.GetComponent<Health>().OnDeath -= RemoveFromSpot;
        }

        OnDeleteFromSpot -= _shootingHandler.ReduceTargets;
    }


    private void RemoveFromSpot()
    {
        OnDeleteFromSpot?.Invoke();
    }


   
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            other.GetComponent<ShootingHandler>().NumberTargets = _numberOfEnemies;

        }
    }
}

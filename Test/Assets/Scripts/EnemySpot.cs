using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpot : MonoBehaviour
{
    
    
    
    private int _numberOfEnemies;
    private Enemy[] _allEnemies;
    private ShootingHandler _shootingHandler;

    private void Awake()
    {
        _allEnemies = GetComponentsInChildren<Enemy>();
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

    }


    private void OnDisable()
    {
        foreach (var enemy in _allEnemies)
        {
            enemy.GetComponent<Health>().OnDeath -= RemoveFromSpot;
        }
        
    }


    private void RemoveFromSpot()
    {
        _shootingHandler.ReduceTargets();
    }


   
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            other.GetComponent<ShootingHandler>().NumberTargets = _numberOfEnemies;
            _shootingHandler = other.GetComponent<ShootingHandler>();

        }
    }
}

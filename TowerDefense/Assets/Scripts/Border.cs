using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Border : MonoBehaviour
{

    [SerializeField] private UnityEvent OnEntryUnit;
    
    
    private GameState _gameState;
    private float _damageWhenAunitEnters;
    


    private void Awake()
    {
        _gameState = FindObjectOfType<GameState>();
    }


    private void Start()
    {
        _damageWhenAunitEnters = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Unit unit)!= null)
        {
            _gameState.GetComponent<Health>().Decrease(_damageWhenAunitEnters);
            OnEntryUnit?.Invoke();
            Destroy(other.gameObject);
        }
    }
}

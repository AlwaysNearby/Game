using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{

    [SerializeField] private Text _life;
    
    private Health _health;


    private void Awake()
    {
        _health = GetComponent<Health>();
    }


    private void Start()
    {
        
        UpdateLifeInUi((int)_health.Current);
        
        _health.OnHit += () =>
        {
            UpdateLifeInUi((int)_health.Current);
        };
        
        _health.OnDeath += () =>
        {
            GameOver();
        };

    }


    private void UpdateLifeInUi(int life)
    {
        print("111111");
        _life.text = "Life: " + life.ToString();
    }
    
    
    
    private void GameOver()
    {}
    

}

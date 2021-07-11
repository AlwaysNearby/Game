using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    public static Balance Instance;



    [SerializeField] private Text _balance;

    public int Cost
    {
        get => _cost;
        private set { ; }
    }
    
    [SerializeField] private int _cost;
    private Text _currentSum;

    

    public void Decrease(int cost)
    {
        _cost -= cost;
        UpdateSum(_cost);
    }


    public void Increase(int cost)
    {
        _cost += cost;
        UpdateSum(_cost);
    }
    
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateSum(_cost);
    }


    private void UpdateSum(int sum)
    {
        _balance.text = String.Concat(sum.ToString(), "$");
    }
    
    
    

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour, ISwitcherState
{

    private PlayerBaseState _currentState;
    private List<PlayerBaseState> _allStates;

    private void Awake()
    {
        var input = FindObjectOfType<TouchScroll>();
        var animator = GetComponent<Animator>();
        _allStates = new List<PlayerBaseState>()
        {
            new PlayerIdle(this, input, animator),
            new PlayerTurn(this, input, animator),
            new PlayerMover(this, input, animator, transform, 3),
        };
    }

    void Start()
    {
        _currentState = _allStates[0];
        _currentState.Enable();
    }

    void Update()
    {
        _currentState.Update();
    }

    public void Switch<T>() where T : PlayerBaseState
    {
        var state = _allStates.Find(s => s is T);
        _currentState.Disable();
        _currentState = state;
        _currentState.Enable();
    }
}

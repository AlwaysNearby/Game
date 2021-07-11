using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Car : MonoBehaviour, ISwitcherState
{


    private BaseState _currentState;
    private List<BaseState> _allStates;
    private Input _input;

    private void Awake()
    {
        
        _input = new Input();
        
        _allStates = new List<BaseState>()
        {
            new CarMover(transform,  this, _input),
            new CarStop(transform, this, _input),
        };
        
    }


    private void OnEnable()
    {
        _input.Enable();
    }


    private void OnDisable()
    {
        _input.Disable();
    }


    void Start()
    {
        _currentState = _allStates[0];
        _currentState.Start();
    }
    
    void Update()
    {
        _currentState.Move();
    }

    public void SwitchState<T>() where T : BaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState.Stop();
        state.Start();
        _currentState = state;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour, ISwitcherState
{

    private BaseState[] _allStates;
    private BaseState _currentState;

    private void Awake()
    {
        _allStates = new BaseState[]
        {
            new PlayerIdle(this, GetComponent<Animator>(), new Input()),
            new PlayerMover( this, GetComponent<Animator>(), GetComponent<MovePointHepler>(), 2.5f),
            new PlayerShooter(this, GetComponent<Animator>(), new Input(), GetComponent<ShootingHandler>())
        };
    }


    private void OnEnable()
    {
        GetComponent<MovePointHepler>().OnFinish += StopAllStates;
    }


    private void OnDisable()
    {
        GetComponent<MovePointHepler>().OnFinish += StopAllStates;
    }


    private void Start()
    {
        
        _currentState = _allStates[0];
        _currentState.Start();

    }
    
    public void SwitchState<T>() where T : BaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState.Stop();
        _currentState = state;
        _currentState.Start();
    }


    private void StopAllStates()
    {
        foreach (var state in _allStates)
        {
            state.Stop();
        }
    }
    
}

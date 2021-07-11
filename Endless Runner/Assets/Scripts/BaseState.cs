using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected readonly Transform _transform;
    protected readonly float _maxSpeed;
    protected readonly float _minSpeed;
    protected readonly float _acceleration;
    protected readonly ISwitcherState _switcherState;
    protected float _currentSpeed;


    public BaseState(Transform transform, ISwitcherState switcherState)
    {
        _switcherState = switcherState;
        _transform = transform;
        _maxSpeed = 3f;
        _acceleration = 0.85f;
        _minSpeed = 0f;
        _currentSpeed = 0f;
    }


    public abstract void Start();

    public abstract void Stop();
    
    public abstract void Move();

    public abstract float CalculateSpeed(float time);


}

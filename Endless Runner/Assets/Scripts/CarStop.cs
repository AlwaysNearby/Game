using System;
using UnityEngine;

public class CarStop : BaseState
{
    private float _startTime;


    public CarStop(Transform transform, ISwitcherState switcherState, Input input) : base(transform, switcherState)
    {
        input.Player.ClickUp.performed += context =>
        {
            _switcherState.SwitchState<CarMover>();
        };
    }

    public override void Start()
    {
        _startTime = Time.time;
    }

    public override void Stop()
    {
        
    }

    public override void Move()
    {
        float currentSpeed = CalculateSpeed(Time.time - _startTime);
        Vector3 currentPoint = _transform.position;
        Vector3 nextPoint = currentPoint + Vector3.forward * currentSpeed;
        _transform.position = Vector3.MoveTowards(currentPoint, nextPoint, Time.deltaTime * currentSpeed);
    }

    public override float CalculateSpeed(float time)
    {
        _currentSpeed = Mathf.Clamp(_maxSpeed - _acceleration * time, _minSpeed, _maxSpeed);
        return _currentSpeed;
    }
}

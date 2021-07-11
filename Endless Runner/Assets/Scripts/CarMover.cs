using UnityEngine;

public class CarMover : BaseState
{
    
    private float _startTime;
    
    public CarMover(Transform transform, ISwitcherState switcherState, Input input) 
        : base(transform, switcherState)
    {
        input.Player.ClickDown.performed += context =>
        {
            Ray ray = Camera.main.ScreenPointToRay(input.Player.ClickPostion.ReadValue<Vector2>());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<Car>() != null)
                {
                    _switcherState.SwitchState<CarStop>();
                }
            }
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
        _currentSpeed = Mathf.Clamp(_currentSpeed + _acceleration * time, _minSpeed, _maxSpeed);
        return _currentSpeed;
    }
}

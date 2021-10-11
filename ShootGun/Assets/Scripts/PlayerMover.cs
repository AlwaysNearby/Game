using DefaultNamespace;
using UnityEngine;

public class PlayerMover : PlayerBaseState
{
    private int _stepBetweenLines;
    private Transform _self;
    private Vector3 _destination;
    public PlayerMover(ISwitcherState switcher, Input input, AnimatorController animator, Transform self, int stepBetweenLines) : base(switcher, animator, input)
    {
        _stepBetweenLines = stepBetweenLines;
        _self = self;
    }

    public override void Start()
    {
        var direction = Vector3.right * Input.ScrollDirection.x;

        if (IsObstacleIn(direction))
        {
            Switcher.Switch<PlayerTurn>();
            AnimatorController.SetTrigger(Parameter.IsObstacle);
        }
        else
        {
            AnimatorController.SetBool(Parameter.Walk, true);
            _destination = _self.position + direction * _stepBetweenLines;
        }
    }

    public override void Update()
    {
        if (!_self.position.Equals(_destination))
        {
            _self.position = Vector3.MoveTowards(_self.position, _destination, Time.deltaTime);
        }
        else
        {
            Switcher.Switch<PlayerTurn>();
        }
            
    }

    public override void Stop()
    { 
        _destination = Vector3.zero;
        AnimatorController.SetBool(Parameter.Walk, false);
    }
    private bool IsObstacleIn(Vector3 direction)
    {
        Debug.DrawRay(_self.position, direction * _stepBetweenLines, Color.red, 1f);
        return Physics.Raycast(_self.position, direction, _stepBetweenLines);
    }
}

using Assets.Scripts;
using DefaultNamespace;
using UnityEngine;

public class PlayerMover : PlayerBaseState
{
    private int _stepBetweenLines;
    private Vector3 _direction;
    private Transform _self;
    private Vector3 _destination;
    private WalkAnimation _walkController;
    

    public PlayerMover(ISwitcherState switcher, TouchScroll input, Animator animator, Transform self, int stepBetweenLines) : base(switcher, input)
    {
        _stepBetweenLines = stepBetweenLines;
        _direction = Vector3.zero;
        _self = self;
        _walkController = new WalkAnimation(animator);
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

    public override void Enable()
    {
        _direction = Vector3.right * Input.Direction.x * _stepBetweenLines;
        
        if (AttemptStep(_direction))
        {
            Switcher.Switch<PlayerTurn>();
            _walkController.SetTrigger(Parametr.IsObstacle);
        }
        else
        {
            _walkController.SetBool(Parametr.Walk, true);
            _destination = _self.position + _direction;
        }
    }

    public override void Disable()
    {
        _direction = Vector3.zero;
        _destination = Vector3.zero;
        _walkController.SetBool(Parametr.Walk, false);
    }

    private bool AttemptStep(Vector3 direction)
    {
        return Physics.Raycast(_self.position, direction, _stepBetweenLines);
    }
}

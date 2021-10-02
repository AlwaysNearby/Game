using Assets.Scripts;
using DefaultNamespace;
using UnityEngine;

public class PlayerIdle : PlayerBaseState
{
    private IdleAnimation _idleController;
    public PlayerIdle(ISwitcherState switcher, TouchScroll input, Animator animator) : base(switcher, input)
    {
        _idleController = new IdleAnimation(animator);
    }

    public override void Update()
    {
       if (!Input.Direction.Equals(Vector2Int.zero))
       {
            Switcher.Switch<PlayerTurn>();
       }

    }

    public override void Enable()
    {
       _idleController.SetBool(Parametr.Idle, true);
       Input.Enable();
    }

    public override void Disable()
    {
        _idleController.SetBool(Parametr.Idle, false);
       Input.Disable();
    }
}

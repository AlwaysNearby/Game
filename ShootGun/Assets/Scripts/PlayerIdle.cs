using DefaultNamespace;
using UnityEngine;

public class PlayerIdle : PlayerBaseState
{
    private ActivatorModeAttack _attackMode;

    public PlayerIdle(ISwitcherState switcher, Touch input, AnimatorController animator, ActivatorModeAttack activator) : base(switcher, animator, input)
    {
        _attackMode = activator;
    }

    public override void Start()
    {
        AnimatorController.SetBool(Parameter.Idle, true);
        Input.Enable();
    }


    public override void Update()
    {  
       if(_attackMode.IsActive)
       {
            Switcher.Switch<PlayerShooter>();
       }
       else if(Input.ScrollDirection != Vector2Int.zero)
       {
            Switcher.Switch<PlayerTurn>();     
       }
    }

    public override void Stop()
    {
        AnimatorController.SetBool(Parameter.Idle, false);
        Input.Disable();
    }
}

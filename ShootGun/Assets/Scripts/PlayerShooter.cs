using DefaultNamespace;
using UnityEngine;

public class PlayerShooter : PlayerBaseState
{
    private ActivatorModeAttack _attackMode;
    private Weapon _gun;
    private ShootingHepler _hepler;

    public PlayerShooter(ISwitcherState switcher, Touch input, AnimatorController animator, ActivatorModeAttack activator, Weapon gun, ShootingHepler helper) : base(switcher, animator, input)
    {
        _attackMode = activator;
        _gun = gun;
        _hepler = helper;
    }

    public override void Start()
    {
        AnimatorController.SetBool(Parameter.Shoot, true);
        Input.Enable();
    }

    public override void Update()
    {
       var clickPosition = Input.PressPosition;

       if (clickPosition != Vector2.zero)
       {
            var position = _hepler.ÑonvertingPixelCoordinates(clickPosition);
            _gun.ShotTorwads(position);
       }


       if(!_attackMode.IsActive)
       { 
          Switcher.Switch<PlayerIdle>();
       }
    }


    public override void Stop()
    {
        AnimatorController.SetBool(Parameter.Shoot, false);
        Input.Disable();
    }


    private void ShotTowards(Ray ray)
    {
        
    }
}

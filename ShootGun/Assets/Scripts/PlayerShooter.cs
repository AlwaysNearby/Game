using DefaultNamespace;
using UnityEngine;

public class PlayerShooter : PlayerBaseState
{
    private Weapon _gun;
    private ShootingHepler _hepler;

    public PlayerShooter(ISwitcherState switcher, Input input, AnimatorController animator, Weapon gun, ShootingHepler helper) : base(switcher, animator, input)
    {
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
            var point = _hepler.ÑonvertingPixelCoordinates(clickPosition);

            if (point == Vector3.zero)
                return;

            _gun.ShotTorwads(point);
       }


       if(!Input.IsActiveAttack)
       {
            Switcher.Switch<PlayerIdle>();
       }
       
    }
    public override void Stop()
    {
        AnimatorController.SetBool(Parameter.Shoot, false);
        Input.Disable();
    }
}

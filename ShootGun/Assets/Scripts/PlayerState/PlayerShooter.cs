using AnimationEvent;
using DefaultNamespace;
using DefaultNamespace.Animator.Parameters;
using UnityEngine;
namespace PlayerState
{
    public class PlayerShooter : PlayerBaseState
    {
        private ProjectileWeapon _gun;
        private ShootingHepler _hepler;

        public PlayerShooter(ISwitcherState switcher, Input input, AnimatorController animator, Weapon gun, ShootingHepler helper) : base(switcher, animator, input)
        {
            _gun = (ProjectileWeapon)gun;
            _hepler = helper;
            
        }

        public override void Start()
        {
            AnimatorController.SetBool(ParameterPlayer.Shoot, true);
            Input.Enable();
        }

        public override void Update()
        {
            var clickPosition = Input.PressPosition;

            if (clickPosition != Vector2.zero)
            {
                var point = _hepler.СonvertingPixelCoordinates(clickPosition);

                if (point.Equals(Vector3.zero))
                {
                    return;
                }
                
                Shot(point);
            }
       
            if(!Input.IsActiveAttack)
            {
                Switcher.Switch<PlayerIdle>();
            }
       
        }
        public override void Stop()
        {
            AnimatorController.SetBool(ParameterPlayer.Shoot, false);
            Input.Disable();
        }


        private void Shot(Vector3 point)
        {
            if (_gun.TryAttack())
            {
                _gun.ShotTowards(point);

                AnimatorController.SetTrigger(ParameterPlayer.Attack);

            }
        }
    }
}

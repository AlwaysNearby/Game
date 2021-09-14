using UnityEngine;

namespace Player
{
    public class PlayerIdle : BaseState
    {

        private readonly Rotator _rotator;

        public PlayerIdle(Transform self,FiringActivator trigger, ISwitcherState switcher, Joystick input) : base(self,trigger, switcher, input)
        {
            _rotator = new Rotator(input.GetComponentInParent<Canvas>(), 2f, self);
        }

        

        public override void Update()
        {
            if (Input.Direction.magnitude > 0.01f)
            {
                Switcher.SwitchState<PlayerMover>();
            }
            else if(Trigger.IsPressed)
            {
                Switcher.SwitchState<PlayerShooter>();
            }
        }

        public override void FixedUpdate()
        {
            _rotator.Rotate();
        }

        public override void Enable()
        {
            
        }

        public override void Disable()
        {
            
        }
    }
}
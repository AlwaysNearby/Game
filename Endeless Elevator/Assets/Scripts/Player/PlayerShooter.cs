using UnityEngine;

namespace Player
{
    public class PlayerShooter : BaseState
    {
        private Mover _mover;
        private Rotator _rotator;
        
        public PlayerShooter(Transform self, FiringActivator trigger, ISwitcherState switcher, Joystick input, float maxSpeed) : base(self, trigger, switcher, input)
        {
            _mover = new Mover(self, maxSpeed);
            _rotator = new Rotator(input.GetComponentInParent<Canvas>(), 3f, self);
        }
     
        public override void Update()
        {
            if (Trigger.IsPressed == false)
            {
                Switcher.SwitchState<PlayerIdle>();
            }
        }
        public override void FixedUpdate()
        {
            Vector3 direction = new Vector3(Input.Horizontal, 0f, Input.Vertical);
            
            _mover.MoveTo(direction);
            _rotator.Rotate();
        }

        public override void Enable()
        {
           AnimationController.SetBool("InShoot", true);
        }

        public override void Disable()
        {
            AnimationController.SetBool("InShoot", false);
        }
    }
}

using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Player
{

    public class PlayerMover : BaseState
    {
        private readonly Mover _mover;
        private readonly Rotator _rotator;

        public PlayerMover(Transform self, FiringActivator trigger, ISwitcherState switcher, Joystick input, float maxSpeed) : base(self, trigger,switcher, input)
        {
            _mover = new Mover(self, maxSpeed);
            _rotator = new Rotator(input.GetComponentInParent<Canvas>() ,5f, self);
        }

     
 
        public override void Update()
        {
            Vector3 input = new Vector3(Input.Horizontal, 0F, Input.Vertical);
            
            AnimationController.SetFloat("speed", input.magnitude);
            AnimationController.SetFloat("directionX", input.x);
            AnimationController.SetFloat("directionY", input.y);
            
            if (Input.Direction.Equals(Vector2.zero))
            {
                Switcher.SwitchState<PlayerIdle>();
            }
            else if(Trigger.IsPressed)
            {
                Switcher.SwitchState<PlayerShooter>();
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
            
        }

        public override void Disable()
        {
           
        }
    }
}
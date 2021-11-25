using AnimatorSystem;
using DefaultNamespace;
using UnityEngine;

namespace PlayerStates
{
    public class PlayerMover : Movable
    {

        public PlayerMover(ISwitcherPlayerState context, AnimatorController animator, PlayerInput input, Rigidbody2D self, float speed) : base(context, animator, input, self, speed)
        {
            
        }

        public override void Start()
        {
            AnimationController.SetBool("Walk", true);
        }

        public override void Update()
        {
            if (Input.Direction.Equals(Vector2.zero))
            {
                Context.Switch<PlayerIdle>();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Context.Switch<PlayerShooter>();
            }
        }

        public override void FixedUpdate()
        {
            MoveAt(Input.Direction);
            RotateAt(Input.Direction);
        }

        public override void Stop()
        {
            AnimationController.SetBool("Walk", false);
        }
        
    }
}
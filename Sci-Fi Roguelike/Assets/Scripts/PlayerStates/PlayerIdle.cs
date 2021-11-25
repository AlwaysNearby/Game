using AnimatorSystem;
using DefaultNamespace;
using UnityEngine;

namespace PlayerStates
{
    public class PlayerIdle : PlayerBaseState
    {
        public PlayerIdle(ISwitcherPlayerState context, AnimatorController animator, PlayerInput input) : base(context,
            animator, input)
        {
        }

        public override void Start()
        {
            AnimationController.SetBool("Idle", true);
        }

        public override void Update()
        {
            if (Input.Direction.Equals(Vector2.zero) == false)
            {
                Context.Switch<PlayerMover>();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Context.Switch<PlayerShooter>();
            }

        }

        public override void FixedUpdate()
        {

        }

        public override void Stop()
        {
            AnimationController.SetBool("Idle", false);
        }
    }
}
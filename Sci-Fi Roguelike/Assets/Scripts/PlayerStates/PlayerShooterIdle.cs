using AnimatorSystem;
using DefaultNamespace;
using UnityEngine;

namespace PlayerStates
{
    public class PlayerShooterIdle : Movable
    {
        private ShootingHelper _shootingHelper;
        
        public PlayerShooterIdle(ISwitcherPlayerState context, AnimatorController animator, PlayerInput input, ShootingHelper shootingHelper, Rigidbody2D self, float speed) : base(context, animator, input,self, speed)
        {
            _shootingHelper = shootingHelper;
        }

        public override void Start()
        {
            AnimationController.SetBool("AttackIdle", true);
        }

        public override void Update()
        {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (_shootingHelper.CheckDotHas(Input.MousePositionInWorldCoordinates) == false)
                {
                    Context.Switch<PlayerShooter>();
                }
            }
            else
            {
       
                if (Input.Direction.Equals(Vector2.zero))
                {
                    Context.Switch<PlayerIdle>();
                }
                else
                {
                    Context.Switch<PlayerMover>();
                }
            }
        }

        public override void FixedUpdate()
        {
            MoveAt(Input.Direction);
            RotateAt(Input.MousePositionInWorldCoordinates - Self.position);
        }

        public override void Stop()
        {
            AnimationController.SetBool("AttackIdle", false);
        }

       
    }
}
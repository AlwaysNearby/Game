using AnimationEvents;
using AnimatorSystem;
using DefaultNamespace;
using UnityEngine;
using Weapons;

namespace PlayerStates
{
    public class PlayerShooter : Movable
    {
        private Timer _delayBeforeTransition;
        private AttackAnimationEventHandler _eventHandler;
        private Weapon _weapon;
        private ShootingHelper _shootingHelper;
        
        public PlayerShooter(ISwitcherPlayerState context, AnimatorController animator, PlayerInput input,
            Rigidbody2D rigidbody2D, float speed, AttackAnimationEventHandler handler, Weapon weapon, ShootingHelper shootingHelper) : base(context, animator, input, rigidbody2D, speed)
        {

            _delayBeforeTransition = new Timer(0.25f);
            _eventHandler = handler;
            _weapon = weapon;
            _shootingHelper = shootingHelper;
        }
        
        public override void Start()
        {
            if (_shootingHelper.CheckDotHas(Input.MousePositionInWorldCoordinates))
            {
                Context.Switch<PlayerShooterIdle>();
                return;
            }
            
            AnimationController.SetBool("Attack", true);
            _eventHandler.OnStartAttack += Shot;
        }
        
        public override void Update()
        {

            if (_shootingHelper.CheckDotHas(Input.MousePositionInWorldCoordinates))
            {
                Context.Switch<PlayerShooterIdle>();
                return;
            }

            if (_delayBeforeTransition.IsStart)
            {
                if (_delayBeforeTransition.IsOver())
                {
                    ChangeState();
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _delayBeforeTransition.Start();
            }
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _delayBeforeTransition.Stop();
            }

        }
        
        public override void FixedUpdate()
        {
            MoveAt(Input.Direction);
            RotateAt(Input.MousePositionInWorldCoordinates - Self.position);
        }

        public override void Stop()
        {
            _delayBeforeTransition.Stop();
            AnimationController.SetBool("Attack", false);
            _eventHandler.OnStartAttack -= Shot;
        }
        
        private void Shot()
        { 
            //_weapon.ShotTowards(Input.MousePositionInWorldCoordinates);
        }
        
     
        
        private void ChangeState()
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
}
using System.Collections.Generic;
using AnimationEvent;
using DefaultNamespace;
using UnityEngine;

namespace PlayerState
{
    [RequireComponent(typeof(PlayerAnimatorController), typeof(ShootingHepler))]
    public class Player : MonoBehaviour, ISwitcherState
    {
        [SerializeField] private Input _input;
        [SerializeField] private Weapon _gun;
    
        private PlayerBaseState _currentState;
        private List<PlayerBaseState> _allStates;

        private void Awake()
        {
            var animationController = GetComponent<AnimatorController>();

            _allStates = new List<PlayerBaseState>()
            {
                new PlayerIdle(this, _input, animationController),
                new PlayerTurn(this, _input, animationController),
                new PlayerMover(this, _input, animationController, transform, 3),
                new PlayerShooter(this, _input, animationController, _gun, GetComponent<ShootingHepler>(), GetComponent<AttackAnimationEvent>()),
            };
        }


        private void Start()
        { 
            _currentState = _allStates[0];
            _currentState.Start();
        }

        private void Update()
        {
            _currentState.Update();
        }
    

        public void Switch<T>() where T : PlayerBaseState
        {
            var state = _allStates.Find(s => s is T);
            _currentState.Stop();
            _currentState = state;
            _currentState.Start();

        }
    
    
    
    }
}

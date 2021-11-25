using System.Collections.Generic;
using AnimationEvents;
using AnimatorSystem;
using DefaultNamespace;
using UnityEngine;
using Weapons;

namespace PlayerStates
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, ISwitcherPlayerState
    {

        private List<PlayerBaseState> _allStates;
        private PlayerBaseState _currentState;

        private void Awake()
        {
            _allStates = new List<PlayerBaseState>()
            {
                new PlayerIdle(this, GetComponentInChildren<AnimatorController>(), GetComponent<PlayerInput>()),
                new PlayerMover(this, GetComponentInChildren<AnimatorController>(), GetComponent<PlayerInput>(), GetComponent<Rigidbody2D>(), 3f),
                new PlayerShooter(this, GetComponentInChildren<AnimatorController>(), GetComponent<PlayerInput>(), GetComponent<Rigidbody2D>(), 1.5f,
                    GetComponentInChildren<AttackAnimationEventHandler>(), GetComponent<Weapon>(), GetComponent<ShootingHelper>()),
                new PlayerShooterIdle(this, GetComponentInChildren<AnimatorController>(), GetComponent<PlayerInput>(), GetComponent<ShootingHelper>(), GetComponent<Rigidbody2D>(), 1.5f),
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


        private void FixedUpdate()
        {
            _currentState.FixedUpdate();
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
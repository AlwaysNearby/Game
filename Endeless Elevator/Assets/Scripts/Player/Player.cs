using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, ISwitcherState
    {
        
        private BaseState _currentState;
        private List<BaseState> _allStates;


        private void Awake()
        {
            Joystick joystick = FindObjectOfType<Joystick>();
            FiringActivator trigger = FindObjectOfType<FiringActivator>();
            
            _allStates = new List<BaseState>()
            {
                new PlayerIdle(transform, trigger, this, joystick),
                new PlayerMover(transform, trigger,this, joystick, 3f),
                new PlayerShooter(transform, trigger,this, joystick, 1f)
            };
        }

        private void Start()
        {
            _currentState = _allStates[0];
        }

        // Update is called once per frame
        private void Update()
        {
            _currentState.Update();
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }

        public void SwitchState<T>() where T : BaseState
        {
            _currentState.Disable();
            _currentState = _allStates.Find(s => s is T);
            _currentState.Enable();
            
        }
    }
}

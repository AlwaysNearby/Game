using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    
    public class PlayerTurn : PlayerBaseState
    {
        private LookDirection _orientation;
        private Timer _timer;
        private TurnAnimation _turnController;
        public PlayerTurn(ISwitcherState switcher, TouchScroll input, Animator animator) : base(switcher, input)
        {
            _orientation = LookDirection.Idle;
            _turnController = new TurnAnimation(animator);
            _timer = new Timer(_turnController.GetAnimationTime(TurnType.LTurn));
        }

        public override void Update()
        {
            if (_timer.IsOver())
            {
                if (_orientation.Equals(LookDirection.Idle))
                {
                    Switcher.Switch<PlayerMover>();
                    _orientation = LookDirection.Side;
                }
                else
                {
                    Switcher.Switch<PlayerIdle>();
                    _orientation = LookDirection.Idle;
                }
            }
        }

        public override void Enable()
        {
            _turnController.SetBool(Parametr.Turn, true);
            _turnController.SetInteger(Parametr.Direction, Input.Direction.x);
            _timer.Start();
        }

        public override void Disable()
        {
            _turnController.SetBool(Parametr.Turn, false);
            _turnController.SetInteger(Parametr.Direction, 0);
        }
        
    }
}
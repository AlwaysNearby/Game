using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEvent
{
    public class AttackAnimationEvent : MonoBehaviour
    {
        public event Action OnEnd;
        public event Action OnStart;
        public event Action OnAttack;

        public void HandleStartAnimationEvent()
        {
            OnStart?.Invoke();
        }

        public void HandleAttackAnimationEvent()
        {
            OnAttack?.Invoke();
        }
        
        public void HandleEndAnimationEvent()
        {
            OnEnd?.Invoke();
        }
        
    }
}
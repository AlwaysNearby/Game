using System;
using UnityEngine;

namespace AnimationEvents
{
    public class AttackAnimationEventHandler : MonoBehaviour
    {
        public event Action OnStartAttack;
        public event Action OnEndAttack;

        public void OnStartAnimation()
        {
            OnStartAttack?.Invoke();
        }

        public void OnEndAnimation()
        {
            OnEndAttack?.Invoke();
        }
        
    }
}
using System;
using UnityEngine;

namespace CollisionDetected
{
    public class ZoneAttack : TriggerHandler
    {
        public event Action<IDamageable> OnEntryTarget;
        
        protected override void Handle(Collider collider)
        {
            if (Check<Border>(collider))
            {
                OnEntryTarget?.Invoke(collider.GetComponent<IDamageable>());
            }
        }
    }
}
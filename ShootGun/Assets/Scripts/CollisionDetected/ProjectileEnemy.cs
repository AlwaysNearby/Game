using PlayerState;
using UnityEngine;

namespace CollisionDetected
{
    public class ProjectileEnemy : TriggerHandler
    {
        [SerializeField] private Projectile _projectile;
        protected override void Handle(Collider collider)
        {
            if (Check<Border>(collider))
            {
                _projectile.DamageAt(collider.GetComponent<IDamageable>());
            }
        }
    }
}
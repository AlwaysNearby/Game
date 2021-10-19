using Enemy;
using UnityEngine;

namespace CollisionDetected
{
    public class ProjectilePlayer : TriggerHandler
    {
        [SerializeField] private Projectile _projectile;
        
        protected override void Handle(Collider collider)
        {
            if (Check<BaseEnemy>(collider))
            {
                _projectile.DamageAt(collider.GetComponent<IDamageable>());
            }
        }
    }
}
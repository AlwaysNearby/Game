using System.Collections.Generic;
using DefaultNamespace.Health;
using UnityEngine;

namespace Weapons
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] protected float Speed;

        private bool _isHasCollision;
        private List<LayerMask> _collisionFilter;
        
        public void Init(Vector2 destination, List<LayerMask> availableTargets)
        {
            _collisionFilter = availableTargets;
            MoveAt(destination);
        }
        
        protected abstract void HandleContact(Collider2D collider);

        protected abstract void MoveAt(Vector2 destination);

        protected void DamageAt(IDamageable target)
        {
            target.Decrease(_damage);
        }
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            HandleContact(other);
        }
    }
}
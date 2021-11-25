using System;
using DefaultNamespace;
using DefaultNamespace.Health;
using UnityEngine;

namespace Weapons
{
    public class Bullet : Projectile
    {
        private Vector2 _destination;
        
        private void Update()
        {
            if (TryMove())
            {
                transform.position = Vector3.MoveTowards(transform.position, _destination, Speed * Time.deltaTime);
            }
        }

        protected override void MoveAt(Vector2 destination)
        {
            _destination = destination;
        }

        protected override void HandleContact(Collider2D collider)
        {
            IDamageable target;

            if (collider.TryGetComponent(out target))
            {
                DamageAt(target);
            }
            
            gameObject.SetActive(false);
        }

        private  bool TryMove()
        {
            if (transform.position.Equals(_destination))
            {
                return false;
            }

            return true;
        }
    }
}
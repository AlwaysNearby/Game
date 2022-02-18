using System;
using Converter;
using UnityEngine;

namespace Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _selfBody;
        private Action<Bullet> _destroyed;

        private void Awake()
        {
            _selfBody = GetComponent<Rigidbody>();
        }

        public void Init(Action<Bullet> destroyed)
        {
            _destroyed = destroyed;
        }

        public void SetVelocity(Vector3 velocity)
        {
	        _selfBody.velocity = velocity;
        }
        
        public void SetDeparturePosition(Vector3 position)
        {
	        transform.position = position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ground ground))
            {
                _destroyed?.Invoke(this);
            }
        }
    }
}

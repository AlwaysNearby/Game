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

        public void Init(Action<Bullet> destroyed, Vector3 positionSpawn)
        {
            _destroyed = destroyed;
            transform.position = positionSpawn;
        }

        public void SetVelocity(Vector3 velocity)
        {
	        _selfBody.velocity = velocity;
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

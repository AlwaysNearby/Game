using System;
using Pool;
using UnityEngine;

namespace Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _selfBody;
        private Action<Bullet> _destroyed;
        
        public void Init(Action<Bullet> destroyed)
		{
            _selfBody = GetComponent<Rigidbody>();
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
    }
}

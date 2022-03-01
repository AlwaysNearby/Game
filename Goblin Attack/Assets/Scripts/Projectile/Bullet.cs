using System;
using Converter;
using UnityEngine;

namespace Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _selfBody;

        private void Awake()
        {
            _selfBody = GetComponent<Rigidbody>();
        }

        public void Init(Vector3 positionSpawn, Vector3 velocity)
        {
            transform.position = positionSpawn;
            _selfBody.velocity = velocity;
        }
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ground ground))
            {
                Destroy(gameObject);
            }
        }
    }
}

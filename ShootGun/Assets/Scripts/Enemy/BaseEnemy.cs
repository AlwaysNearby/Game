using System;
using Animators.EnemyAnimator;
using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAnimatorController))]
    public abstract class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private LayerMask _target;
        
        protected AnimatorController AnimatorController;

        private float _speed;
        
        protected virtual void Awake()
        {
            AnimatorController = GetComponent<AnimatorController>();
        }

        public void Init(float speed)
        {
            _speed = speed;
        }
        
        public bool TryMove(Vector3 direction)
        {
            if (Physics.Raycast(transform.position, direction, 1f, _target))
            {
                return false;
            }
            
            return true;
        }
        
        public void MoveAt(Vector3 direction)
        {
            Vector3 currentPosition = transform.position;
            Vector3 endPosition = currentPosition + direction * _speed;
            Vector3 delta = Vector3.MoveTowards(currentPosition, endPosition, Time.deltaTime * _speed);

            transform.position = delta;
        }
    }
}

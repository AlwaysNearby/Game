using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
    public abstract class BaseEnemy : MonoBehaviour, ITarget
    {
        [SerializeField] private float _speed;

        public void MoveAt(Vector3 direction)
        {
            Vector3 currentPosition = transform.position;
            Vector3 endPosition = currentPosition + direction * _speed;
            Vector3 delta = Vector3.MoveTowards(currentPosition, endPosition, Time.deltaTime * _speed);

            transform.position = delta;
        }

    }
}

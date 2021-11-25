using Enemy;
using UnityEngine;

namespace DefaultNamespace.Factory
{
    [System.Serializable]
    public class EnemyConfig
    {
        public BaseEnemy Prebaf;

        [SerializeField] private float _speedMin, _speedMax;


        public float Speed => Random.Range(_speedMin, _speedMax);

    }
}
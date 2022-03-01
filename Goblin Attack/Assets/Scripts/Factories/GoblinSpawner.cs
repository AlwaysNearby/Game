using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Factories
{
    public class GoblinSpawner : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _speedRate;
        
        private IFactoryGoblin<GoblinType> _factoryGoblin;
        private float _spawnProgress;
        
        [Inject]
        private void Construct(IFactoryGoblin<GoblinType> factoryGoblin)
        {
            _factoryGoblin = factoryGoblin;
        }

        private void Update()
        {
            _spawnProgress += _speedRate * Time.deltaTime;

            while (_spawnProgress >= 1f)
            {
                _spawnProgress -= 1f;
                Spawn();
            }
        }

        public void Initialize()
        {
            _factoryGoblin.Load();
        }


        private void Spawn()
        {
            Vector3 randomPlace = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            
            _factoryGoblin.Create(GoblinType.Melee, randomPlace);
        }
    }
}
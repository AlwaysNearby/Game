using Projectile;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class BulletSpawner : MonoBehaviour, IInitializable
    {
        private IFactoryBullet<BulletType> _factory;

        [Inject]
        private void Construct(IFactoryBullet<BulletType> factory)
        {
            _factory = factory;
        }

        public void Spawn(BulletType type, Vector3 position, Vector3 velocity)
        {
            _factory.Create(type, position, velocity);
        }


        public void Initialize()
        {
            _factory.Load();
        }
    }
}
using System;
using Projectile;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Factories
{
    public enum BulletType
    {
        Default = 0,
    }

    public class BulletFactory : IFactoryBullet<BulletType>
    {
        private readonly DiContainer _diContainer;

        private Object _template;
        
        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            _template = Resources.Load("Bullets/Bullet");
        }

        public void Create(BulletType type, Vector3 spawnPosition, Vector3 velocity)
        {
            switch (type)
            {
                case BulletType.Default:
                    GameObject template = _diContainer.InstantiatePrefab(_template);
                    Bullet bullet = template.AddComponent<Bullet>();
                    bullet.Init(spawnPosition, velocity);
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
using Projectile;
using UnityEngine;
using Factories;

namespace Pool
{
    public class BulletPool : ObjectPool<Bullet, BulletType>
    {
        [SerializeField] private BulletFactory _bulletFactory;
        protected override Bullet CreateElement(BulletType typeTemplate)
        {
           return _bulletFactory.Create(typeTemplate, ReturnToPool);
        }
        
    }
}
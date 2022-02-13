using Projectile;
using UnityEngine;
using Factories;

namespace Pool
{
    public class BulletPool : ObjectPool<Bullet>
    {
        [SerializeField] private BulletFactory _bulletFactory;
        
        protected override Bullet CreateElement()
        {
           return _bulletFactory.GetBullet(ReturnToPool);
        }
    }
}
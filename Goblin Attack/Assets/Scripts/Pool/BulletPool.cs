using Projectile;
using UnityEngine;
using Factories;

namespace Pool
{
    public class BulletPool : ObjectPool<Bullet>
    {
        protected override Bullet CreateElement(Bullet template)
        {
            return Instantiate(template);
        }
        
    }
}
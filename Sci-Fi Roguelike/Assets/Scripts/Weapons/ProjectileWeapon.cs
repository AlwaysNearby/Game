using UnityEngine;

namespace Weapons
{
    public class ProjectileWeapon : Weapon
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _spawnPosition;

        

        public override void ShotTowards(Vector2 position)
        {
            LaunchTo(position);
        }


        private void LaunchTo(Vector2 destination)
        {
            var projectile = Instantiate(_projectile, _spawnPosition.position, Quaternion.identity);

            projectile.Init(destination, _availableTargets);
        }
        
    }
}
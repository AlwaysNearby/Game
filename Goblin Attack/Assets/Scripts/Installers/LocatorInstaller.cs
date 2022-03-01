using UnityEngine;
using Zenject;
using Character;
using Converter;
using Factories;
using Projectile;
using TrajectorySystem;

namespace Installers
{
    public class LocatorInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrebaf;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private PixelCoordinateConverter _converter;
        [SerializeField] private Trajectory _trajectory;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private GoblinSpawner _goblinSpawner;

        public override void InstallBindings()
        {
            BindFactoryBullet();
            BindFactoryGoblin();
            BindTrajectory();
            BindConverter();
            BindPlayer();
 
        }

        private void BindFactoryGoblin()
        {
            Container
                .Bind<IFactoryGoblin<GoblinType>>()
                .To<GoblinFactory>()
                .AsSingle();

            Container
                .Bind<GoblinSpawner>()
                .FromInstance(_goblinSpawner)
                .AsSingle();

            Container
                .BindInterfacesTo<GoblinSpawner>()
                .FromInstance(_goblinSpawner);
        }

        private void BindFactoryBullet()
        {
            Container
                .Bind<IFactoryBullet<BulletType>>()
                .To<BulletFactory>()
                .AsSingle();
            
            Container
                .Bind<BulletSpawner>()
                .FromInstance(_bulletSpawner)
                .AsSingle();

            Container
                .BindInterfacesTo<BulletSpawner>()
                .FromInstance(_bulletSpawner);
        }

        private void BindTrajectory()
        {
            Container
                .Bind<Trajectory>()
                .FromInstance(_trajectory)
                .AsSingle();
        }

        private void BindConverter()
        {
            Container
                .Bind<PixelCoordinateConverter>()
                .FromInstance(_converter)
                .AsSingle();
        }

        private void BindPlayer()
        {
            Player player =  Container.
                InstantiatePrefabForComponent<Player>(_playerPrebaf, _startPoint.position, Quaternion.identity,
                null);

            Container.
                Bind<Player>().
                FromInstance(player).
                AsSingle();
            
        }
    }
}
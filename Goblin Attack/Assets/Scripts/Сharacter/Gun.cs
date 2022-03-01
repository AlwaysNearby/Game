using Factories;
using ScriptableObjects.PlayerBundle;
using UnityEngine;
using TrajectorySystem;
using Zenject;

namespace Character
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Transform _launchPoint;

        private BulletSpawner _bulletSpawner;
        private Trajectory _trajectory;
        
        [Inject]
        private void Construct(Trajectory trajectoryRenderer, BulletSpawner bulletSpawner)
        {
            _trajectory = trajectoryRenderer;
            _bulletSpawner = bulletSpawner;
        }

        public void LookAt(Vector3 pointView)
        {
            Vector3 lookDirection = pointView - transform.position;

            lookDirection.y = 0f;

            Quaternion torque = Quaternion.LookRotation(lookDirection);

            transform.rotation = torque;
        }

        public void LaunchTo(Vector3 targetPoint)
        {
            Vector3 velocity = _trajectory.СalculateDirectionLaunch(_playerData.AngleLaunch, _launchPoint, targetPoint);

           _bulletSpawner.Spawn(BulletType.Default, _launchPoint.position, velocity);
        }

        public void ShowTrajectoryBullet(Vector3 targetPoint)
        {
            Vector3 velocity = _trajectory.СalculateDirectionLaunch(_playerData.AngleLaunch, _launchPoint, targetPoint);

            _trajectory.Draw(velocity, _launchPoint.position, targetPoint);
        }

        public void HideTrajectoryBullet()
        {
            _trajectory.Clear();
        }
    }
}
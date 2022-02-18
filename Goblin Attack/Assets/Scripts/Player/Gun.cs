using Factories;
using Pool;
using Projectile;
using ScriptableObjects.PlayerBundle;
using UnityEngine;
using TrajectorySystem;

namespace Player
{
	public class Gun : MonoBehaviour
	{
		[SerializeField] private Transform _placeLaunch;
		[SerializeField] private Trajectory _trajectory;
		[SerializeField] private PlayerData _playerData;
		
		private IObjectPool<Bullet, BulletType> _poolElementGetter;
		public void Init(IObjectPool<Bullet, BulletType> poolElementGetter)
		{
			_poolElementGetter = poolElementGetter;
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
			Bullet bullet = _poolElementGetter.GetTemplate(BulletType.Default);

			Vector3 velocity = _trajectory.СalculateDirectionLaunch(_playerData.AngleLaunch, targetPoint);

			bullet.SetVelocity(velocity);
			bullet.SetDeparturePosition(_placeLaunch.position);
		}

		public void ShowTrajectoryBullet(Vector3 targetPoint)
		{
			Vector3 velocity = _trajectory.СalculateDirectionLaunch(_playerData.AngleLaunch, targetPoint);
			
			_trajectory.Draw(velocity, targetPoint);
		}

		public void HideTrajectoryBullet()
		{
			_trajectory.Clear();
		}
	}
}

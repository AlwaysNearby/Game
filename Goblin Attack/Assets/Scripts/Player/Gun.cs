using System;
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
		[SerializeField] private GameObject _bulletFactoryContainer;

		private IFactory<Bullet, BulletType> _factory;

		private void OnValidate()
		{

			if(_bulletFactoryContainer != null && _bulletFactoryContainer.GetComponent<IFactory<Bullet, BulletType>>() == null)
			{
				_bulletFactoryContainer = null;
			}

		}

		private void Awake()
		{
			if(_bulletFactoryContainer == null)
			{
				throw new Exception("No factory assigned");
			}

			_factory = _bulletFactoryContainer.GetComponent<IFactory<Bullet, BulletType>>();
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
			Bullet bullet = _factory.Get(BulletType.Default, _placeLaunch.position);

			Vector3 velocity = _trajectory.СalculateDirectionLaunch(_playerData.AngleLaunch, targetPoint);

			bullet.SetVelocity(velocity);
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

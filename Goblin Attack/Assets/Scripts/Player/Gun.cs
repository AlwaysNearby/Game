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
		[SerializeField] private GameObject _bulletStorage;
		
		private IObjectPool<Bullet, BulletType> _poolElementGetter;

		private void OnValidate()
		{
			if (_bulletStorage != null && _bulletStorage.GetComponent<IObjectPool<Bullet, BulletType>>() == null)
			{
				_bulletStorage = null;
			}
		}

		private void Awake()
		{
			_poolElementGetter = _bulletStorage.GetComponent<IObjectPool<Bullet, BulletType>>();
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
			Bullet bullet = _poolElementGetter.GetElement(BulletType.Default);

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

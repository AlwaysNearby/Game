using System.Security.Claims;
using Pool;
using Projectile;
using UnityEngine;
using TrajectorySystem;


namespace Player
{
	public class Gun : MonoBehaviour
	{
		[SerializeField] private float _angleLaunch;
		[SerializeField] private Transform _placeLaunch;
		[SerializeField] private float _minAngleRotation, _maxAngleRotation;

		private IObjectPool<Bullet> _poolElementGetter;
		private Trajectory _trajectory;
		public void Init(IObjectPool<Bullet> poolElementGetter, Trajectory trajectory)
		{
			_poolElementGetter = poolElementGetter;
			_trajectory = trajectory;
		}
		
		public void LookAt(Vector3 pointView)
		{
			Vector3 lookDirection = pointView - transform.position;

			lookDirection.y = 0f;

			float angleRotation = Vector3.SignedAngle(Vector3.forward, lookDirection, Vector3.up);

			transform.rotation = ClampRotation(angleRotation, _minAngleRotation, _maxAngleRotation);
		}

		public void LaunchTo(Vector3 targetPoint)
		{
			Bullet bullet = _poolElementGetter.GetElement();

			Vector3 velocity = _trajectory.СalculateDirectionLaunch(_angleLaunch, targetPoint);

			bullet.SetVelocity(velocity);
			bullet.SetDeparturePosition(_placeLaunch.position);
		}

		public void ShowTrajectoryBullet(Vector3 targetPoint)
		{
			Vector3 velocity = _trajectory.СalculateDirectionLaunch(_angleLaunch, targetPoint);
			
			_trajectory.Draw(velocity, targetPoint);
		}

		private Quaternion ClampRotation(float torque, float minAngle, float maxAngle)
		{
			float clampAngle = Mathf.Clamp(torque, minAngle, maxAngle);
			
			return Quaternion.AngleAxis(clampAngle, Vector3.up);
		}
	}
}

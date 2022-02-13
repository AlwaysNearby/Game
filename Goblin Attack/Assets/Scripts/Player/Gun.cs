using Factories;
using Pool;
using Projectile;
using UnityEngine;

namespace Player
{
	public class Gun : MonoBehaviour
	{
		[SerializeField] private float _speedLaunch;
		[SerializeField] private Transform _placeLaunch;

		private IPoolElementGetter<Bullet> _poolElementGetter;

		public void Init(IPoolElementGetter<Bullet> poolElementGetter)
		{
			_poolElementGetter = poolElementGetter;
		}
		
		public void LookAt(Vector3 pointView)
		{
			Vector3 lookDirection = pointView - transform.position;

			lookDirection.y = 0f;

			Quaternion torque = Quaternion.LookRotation(lookDirection, Vector3.up);

			transform.rotation = torque;
		}

		public void LaunchTo(Vector3 targetPoint)
		{
			Vector3 direction = (targetPoint - _placeLaunch.position).normalized;

			direction.y = 0;

			Bullet bullet = _poolElementGetter.GetElement();

			bullet.SetVelocity(direction * _speedLaunch);
			bullet.SetDeparturePosition(_placeLaunch.position);
		}

	}
}

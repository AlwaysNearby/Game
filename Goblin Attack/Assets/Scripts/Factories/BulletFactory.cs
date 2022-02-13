using System;
using Pool;
using UnityEngine;
using Projectile;

namespace Factories
{
	public class BulletFactory : MonoBehaviour
	{
		[SerializeField] private Bullet _template;

		public Bullet GetBullet(Action<Bullet> returnPool)
		{
			Bullet bullet = Instantiate(_template);

			bullet.Init(returnPool);
			bullet.GetComponent<CameraDepartureDetector>().Init(returnPool, bullet);

			return bullet;
		}
	}
}
using System;
using UnityEngine;
using Projectile;
using Pool;

namespace Factories
{
	public enum BulletType
	{
		Default,
	}

	public class BulletFactory : MonoBehaviour, IFactory<Bullet, BulletType>
	{
		[SerializeField] private Bullet _templateDefault;
		[SerializeField] private GameObject _bulletPoolContainer;

		private IObjectPool<Bullet> _pool;

		private void OnValidate()
		{
			if(_bulletPoolContainer != null && _bulletPoolContainer.GetComponent<IObjectPool<Bullet>>() == null)
			{
				_bulletPoolContainer = null;
			}
		}

		private void Awake()
		{
			if(_bulletPoolContainer == null)
			{
				throw new Exception("No pool assigned");
			}

			_pool = _bulletPoolContainer.GetComponent<IObjectPool<Bullet>>();
		}

		public Bullet Get(BulletType template, Vector3 positionSpawn)
		{
			switch (template)
			{
				case BulletType.Default:
					Bullet bulletDefault = _pool.GetElement(_templateDefault);
					bulletDefault.Init(_pool.ReturnPool, positionSpawn);
					return bulletDefault;
				default:
					throw new Exception("No such template");
			}
			
			
		}
	}
}
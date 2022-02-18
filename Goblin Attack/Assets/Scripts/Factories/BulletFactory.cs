using System;
using UnityEngine;
using Projectile;

namespace Factories
{
	public enum BulletType
	{
		Default,
	}
	public class BulletFactory : MonoBehaviour
	{
		[SerializeField] private Bullet _templateDefault;
		public Bullet Create(BulletType typeTemplate, Action<Bullet> returnPool)
		{
			switch (typeTemplate)
			{
				case BulletType.Default:
					Bullet bulletDefault = Instantiate(_templateDefault);
					bulletDefault.Init(returnPool);
					return bulletDefault;
				default:
					throw new Exception();
			}
			
			
		}
	}
}
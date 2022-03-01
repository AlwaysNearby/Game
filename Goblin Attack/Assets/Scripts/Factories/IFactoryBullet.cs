using UnityEngine;
using System;

namespace Factories
{
	public interface IFactoryBullet<T> : IFactoryInitialization where T : Enum
	{
		public void Create(T type, Vector3 at, Vector3 velocity);
	}
}
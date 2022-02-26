using UnityEngine;
using System;

namespace Factories
{
	public interface IFactory<T, U> where T : MonoBehaviour where U : Enum
	{
		public T Get(U template, Vector3 spawnPosition);
		
	}
}
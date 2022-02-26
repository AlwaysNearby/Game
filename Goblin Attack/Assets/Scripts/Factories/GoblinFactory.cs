using UnityEngine;
using Enemies;
using Pool;
using System;

namespace Factories
{
	public enum GoblinType
	{
		Melee,
	}

	public class GoblinFactory : MonoBehaviour, IFactory<Goblin, GoblinType>
	{
		[SerializeField] private GameObject _goblinPoolContainer;
		[SerializeField] private Goblin _meleeTemplate;

		private IObjectPool<Goblin> _pool;

		private void OnValidate()
		{
			if(_goblinPoolContainer != null && _goblinPoolContainer.GetComponent<IObjectPool<Goblin>>() == null)
			{
				_goblinPoolContainer = null;
			}

		}

		private void Awake()
		{
			if(_goblinPoolContainer == null)
			{
				throw new Exception("No assigned pool");
			}

			_pool = _goblinPoolContainer.GetComponent<IObjectPool<Goblin>>();
		}

		public Goblin Get(GoblinType template, Vector3 spawnPosition)
		{
			switch(template)
			{
				case GoblinType.Melee:
					Goblin melee = _pool.GetElement(_meleeTemplate);
					melee.Init(spawnPosition);
					return melee;
				default:
					throw new Exception("No such template");

			}
		}
	}
}
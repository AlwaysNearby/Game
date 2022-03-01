using UnityEngine;
using Factories;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Enemies
{
	// // public class GoblinSpawner : MonoBehaviour
	// // {
	// // 	[SerializeField] private GameObject _factoryGoblinContainer;
	// // 	[SerializeField] private float _spawnSpeed;
	// // 	[SerializeField] private List<Transform> _placementPoints;
	// //
	// // 	private IFactory<Goblin, GoblinType> _factory;
	// // 	private float _spawnProgress;
	// //
	// // 	private void OnValidate()
	// // 	{
	// // 		if(_factoryGoblinContainer != null && _factoryGoblinContainer.GetComponent<IFactory<Goblin, GoblinType>>() == null)
	// // 		{
	// // 			_factoryGoblinContainer = null;
	// // 		}
	// // 	}
	// //
	// // 	private void Awake()
	// // 	{
	// // 		if(_factoryGoblinContainer == null)
	// // 		{
	// // 			throw new Exception("No assigned FactoryGoblin");
	// // 		}
	// //
	// // 		_factory = _factoryGoblinContainer.GetComponent<IFactory<Goblin, GoblinType>>();
	// // 	}
	// //
	// // 	private void Update()
	// // 	{
	// // 		_spawnProgress += _spawnSpeed * Time.deltaTime;
	// //
	// // 		while(_spawnProgress >= 1f)
	// // 		{
	// // 			_spawnProgress -= 1f;
	// // 			Spawn();
	// // 		}
	// // 	}
	// //
	// // 	private void Spawn()
	// // 	{
	// // 		Vector3 placement = _placementPoints[Random.Range(0, _placementPoints.Count)].position;
	// //
	// // 		_factory.Get(GoblinType.Melee, placement);
	// // 	}
	// }
}
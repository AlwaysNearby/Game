using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneratorWave : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Transform[] _spawnPlace;

    public void CreateWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            EnemyType randEnemy = (EnemyType) Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
            _enemyFactory.Instance(randEnemy, _spawnPlace[Random.Range(0, _spawnPlace.Length)]);
        }
    }
}

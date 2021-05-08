using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy[] allEnemy;

    private GeneratorWave _makerWave;
    private SpawnWave _graduate;

    private int _countEnemy;
    private int _minEnemy;
    private int _maxEnemy;

    public void ReductionOfMobs()
    {
        _countEnemy--;
        if(_countEnemy <= 0)
        {
            CreateNewWawe();
        }
    }


    private void Awake()
    {
        _makerWave = GetComponent<GeneratorWave>();
        _graduate = GetComponent<SpawnWave>();
    }

    void Start()
    {
        CreateNewWawe();
    }
   
    private void CreateNewWawe()
    {
        _minEnemy = Random.Range(1, 5);
        _maxEnemy = Random.Range(5, 11);
        _countEnemy = Random.Range(_minEnemy, _maxEnemy);
        InitWave();
    }

    private void InitWave()
    {
       var wave =  _makerWave.CreateWave(allEnemy, _countEnemy);
        _graduate.SendMobsForWave(wave);
    }


}

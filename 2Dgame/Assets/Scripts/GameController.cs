using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  
    private WaweGenerator _generatorNewWawe;
    [SerializeField] private SpawnWawe _spawnNewWawe;
    [SerializeField] private GameObject[] _allMobs;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject MainTarget;

    private Vector2 startPosMainTarget = new Vector2(0, 0);
    private Vector2 startPosPlayer = new Vector2(1, 1);

    private void Awake()
    {
        _generatorNewWawe = GetComponent<WaweGenerator>();
        var spawn = Instantiate(_spawnNewWawe.gameObject);
        _spawnNewWawe = spawn.GetComponent<SpawnWawe>();
    }

    private void Start()
    {
        InitGame();
    }


    private void CreateNewWawe()
    {
        _generatorNewWawe.Count = Random.Range(1, 11);
        _generatorNewWawe.CreateWawe(_allMobs);
        _spawnNewWawe.StartCoroutine(_spawnNewWawe.WaweRelease(_generatorNewWawe.GetWawe()));
    }

  
    private void InitGame()
    {
        Instantiate(Player, startPosPlayer, Quaternion.identity);
        Instantiate(MainTarget, startPosMainTarget, Quaternion.identity);
        CreateNewWawe();
    }

    public void IncreaseMobInWawe()
    {
        _generatorNewWawe.Count = _generatorNewWawe.Count - 1;
        if(_generatorNewWawe.Count <= 0)
        {
            CreateNewWawe();
        }
    }
}

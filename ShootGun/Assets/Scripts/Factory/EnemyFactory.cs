using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Factory;
using Enemy;
using UnityEngine;

public enum EnemyType
{
    Melee,
}


public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private EnemyConfig _melee;

    public void Instance(EnemyType type, Transform place)
    {
        var config = GetConfig(type);

        BaseEnemy enemy = Instantiate(config.Prebaf, place.position, Quaternion.identity);

        enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        
        enemy.Init(config.Speed);
    }


    private EnemyConfig GetConfig(EnemyType type)
    {
        EnemyConfig enemy = default;
        
        switch (type)
        {
            case EnemyType.Melee:
                enemy = _melee;
                break;
        }

        return enemy;
    }
}

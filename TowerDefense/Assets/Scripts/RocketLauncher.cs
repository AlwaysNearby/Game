using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RocketLauncher : AttackTower, IChoosable
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Transform _spawnPositionRocket;


    

    public override void Start()
    {
        base.Start();


        Attack.OnStartReload += () =>
        {
            SetNewSprite(level.ReloadSprite[level.Current]);
        };

        Attack.OnEndReload += () =>
        {
            SetNewSprite(level.LevelSprite[level.Current]);
        };

    }


    public override void Shoot(Unit target)
    {
        if (Attack.AttemptShoot())
        {
            var rocket = Instantiate(_rocket, _spawnPositionRocket.position, Quaternion.identity);
            rocket.Target = target;
            rocket.OnEnterUnit += RocketDamageTo;
        }
        LookAt(target);
    }



    public void RocketDamageTo(Unit target)
    {
        Attack.DamageTo(target.Health);
    }


    public Unit Select(List<Unit> targets)
    {
        throw new NotImplementedException();
    }

  
}

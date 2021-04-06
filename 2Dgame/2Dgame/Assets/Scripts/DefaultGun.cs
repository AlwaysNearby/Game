using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : Weapon
{

    [SerializeField] private GameObject _prebafBullet;
    private float _lastTime;
    [SerializeField] private float Overheat;

    public override void Shoot(Vector3 target, Vector3 arrowPos)
    {
        if (CheckRecharge(_lastTime))
        {
            CreateBullet(target - arrowPos, _prebafBullet);
            _lastTime = Time.time + Overheat;
            StartReload(_lastTime);
        }
       

    }


    public override void StartReload(float _lastReload)
    {
        base.StartReload(_lastReload);
    }

}

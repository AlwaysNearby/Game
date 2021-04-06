using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstGun : Weapon
{

    [SerializeField] private GameObject _prebafBullet;

    private int _numberOfQueues = 3;
    private float _lastTime = 0f;
    private bool nowShoot = false;


   [SerializeField] private float Overheat;



    public override void Shoot(Vector3 target, Vector3 arrowPos)
    {
        if (CheckRecharge(_lastTime) && !nowShoot)
        {
            StartCoroutine(BurstShooting(target, arrowPos));
            nowShoot = true;

        }
    }



    private IEnumerator BurstShooting(Vector3 target, Vector3 arrowPos)
    {
        var queues = 0;
        while(queues < _numberOfQueues)
        {
            CreateBullet(target - arrowPos, _prebafBullet);
            queues++;
            yield return new WaitForSeconds(0.2f);
        }
        _lastTime = Time.time + Overheat;
        nowShoot = false;
        StartReload(_lastTime);



    }



    public override void StartReload(float _lastReload)
    {
        base.StartReload(_lastReload);
    }




}

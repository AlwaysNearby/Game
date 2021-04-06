using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridentGun : Weapon
{
    [SerializeField] private GameObject _prebafBullet;
    [SerializeField] private float Overheat;
    private const int _numberOfEndsOfTheTrident = 3;
    private float _lastTime = 0;

    public override void Shoot(Vector3 target, Vector3 arrowPos)
    {
        if (CheckRecharge(_lastTime))
        {
            var direction = target - arrowPos;
            var angle = 0.5f;
            for (var i = 0; i < _numberOfEndsOfTheTrident; i++)
            {

                CreateBullet(new Vector3(direction.x * Mathf.Cos(angle) - direction.y * Mathf.Sin(angle), direction.y * Mathf.Cos(angle) + direction.x * Mathf.Sin(angle), 0), _prebafBullet);
                angle -= 0.5f;

            }
            _lastTime = Time.time + Overheat;
            StartReload(_lastTime);
        }
      

    }




    public override void StartReload(float _lastReload)
    {
        base.StartReload(_lastReload);
    }








}

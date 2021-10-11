using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootingHepler))]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Ammo _ammo;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _reloadBetweenShot;
    [SerializeField] private Projectile _prebaf;
    [SerializeField] private Transform _projectileSpawn;

    private Timer _timeBetweenShots;
    private Timer _timeReload;

    protected virtual void Awake()
    {
        _timeBetweenShots = new Timer(_reloadBetweenShot);
        _timeReload = new Timer(_reloadTime);
    }

    private void Start()
    {
        _ammo.Init();
    }

    private void OnEnable()
    {
        _timeReload.OnEnd += _ammo.Fill;
    }

    private void OnDisable()
    {
        _timeReload.OnEnd -= _ammo.Fill;
    }

    public abstract void ShotTorwads(Vector3 point);

    protected bool TryShot()
    {
        if(_timeReload.IsOver() == false)
        {
            return false;   
        }
       
        if(_timeBetweenShots.IsOver() == false)
        {
            return false;
        }

        if(_ammo.CurrentCount <= 0)
        {
            return false;
        }

        return true;
    }


    protected void Shot(Vector3 point)
    {
        var direction = (point - _projectileSpawn.position).normalized;

        Quaternion lookDirection = Quaternion.LookRotation(direction);
        Projectile projectile = Instantiate(_prebaf, _projectileSpawn.position, lookDirection);
        projectile.Direction = direction;

        _ammo.Reduce();
        _timeBetweenShots.Start();
        
        if(_ammo.CurrentCount == 0)
        {
            _timeReload.Start();
        }
    }

}

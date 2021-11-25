using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public abstract class ProjectileWeapon : Weapon
{
    [SerializeField] private Transform _projectileSpawn;
    [SerializeField] private Projectile _prebaf;
    [SerializeField] private int _countShot;

    private List<Vector3> _positions;
    private Ammo _ammo;

    protected override void Awake()
    {
        base.Awake();
        
        _ammo = new Ammo(_countShot);
    }
    
    private void Start()
    {
        AttackAnimationEvent.OnStart += () =>
        {
            _ammo.Reduce();
        };

        AttackAnimationEvent.OnEnd += () =>
        {
            if (_ammo.CurrentCount <= 0)
            {
                ReloadTimer.Start();
            }
        };
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ReloadTimer.OnEnd += _ammo.Fill;
    }


    protected override void OnDisable()
    {
        base.OnDisable();
        ReloadTimer.OnEnd -= _ammo.Fill;
    }


    public abstract void ShotTowards(Vector3 point);

    public override bool TryAttack()
    {
        if (base.TryAttack() == false)
        {
            return false;
        }

        return true;
    }
    

    protected void AddShot(params Vector3[] point)
    {
        _positions = point.ToList();
    }


    protected override void Attack()
    {
        int count = _positions.Count;

        for (var i = 0; i < count; i++)
        {
            var position = _positions[i];
            
            var direction = (position - _projectileSpawn.position).normalized;

            Quaternion lookDirection = Quaternion.LookRotation(direction);
            Projectile projectile = Instantiate(_prebaf, _projectileSpawn.position, lookDirection);
            projectile.Direction = direction;
            
        }
        
        _positions.Clear();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class MeleeWeapon : Weapon
{
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _availableTarget;
    [SerializeField] private Transform _positionToAttack;
    [SerializeField] private float _range;

    private List<Collider> _targets;

    protected override void Awake()
    {
        base.Awake();
        
        _targets = new List<Collider>();


        AttackAnimationEvent.OnEnd += () =>
        {
            ReloadTimer.Start();
        };
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    

    public override bool TryAttack()
    {
        if (base.TryAttack() == false)
        {
            return false;
        }
        
        return true;
    }
    
    protected override void Attack()
    {
        _targets = Physics.OverlapSphere(_positionToAttack.position, _range, _availableTarget).ToList();
        
        foreach (var target in _targets)
        {
            if (target.gameObject.activeSelf)
            {
                target.GetComponent<IDamageable>().Damage(_damage);
            }
        }
        
        _targets.Clear();
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_positionToAttack.position, _range);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class AttackTower : Tower
{
    
    private List<Unit> _targets;



    private Coroutine _startShoot;
    protected Attack Attack;
    
    public virtual void Start()
    {
        _targets = new List<Unit>();
        Attack = new Attack(level);
        
    }


    public abstract void Shoot(Unit target);


    public virtual void LookAt(Unit target)
    {
        var direction = target.transform.position - transform.position;
        var angleInDegrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, angleInDegrees);
    }

    public override void Upgrade()
    {
        Attack.Reset();
        base.Upgrade();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Unit>() != null)
        {
            var targetUnit = other.GetComponent<Unit>();

            
            _targets.Add(targetUnit);

            if (_startShoot == null)
            {
                _startShoot = StartCoroutine(Shooting(_targets));
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Unit>() != null)
        {
            _targets.Remove(other.GetComponent<Unit>());

            if (_targets.Count == 0)
            {
                _startShoot = null;
            }
        }
    }
    
    private IEnumerator Shooting(List<Unit> targets)
    {
        while (targets.Count > 0)
        {

            Shoot(targets[0]);

            yield return null;
        }
    }
    
    
}





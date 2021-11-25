using System;
using AnimationEvent;
using DefaultNamespace;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Timer ReloadTimer;
    
    protected AttackAnimationEvent AttackAnimationEvent;

    private bool _isAttack;

    protected abstract void Attack();

    protected virtual void Awake()
    {
        AttackAnimationEvent = GetComponentInParent<AttackAnimationEvent>();
        
        AttackAnimationEvent.OnStart += () =>
        {
            _isAttack = true;
        };

        AttackAnimationEvent.OnEnd += () =>
        {
            _isAttack = false;
        };
    }

    protected virtual void OnEnable()
    {
        AttackAnimationEvent.OnAttack += Attack;
    }

    protected virtual void OnDisable()
    {
        AttackAnimationEvent.OnAttack -= Attack;
    }


    public virtual bool TryAttack()
    {
        if (ReloadTimer.IsOver() == false)
        {
            return false;
        }

        if (_isAttack)
        {
            return false;
        }
        
        return true;
    }
    
    
}


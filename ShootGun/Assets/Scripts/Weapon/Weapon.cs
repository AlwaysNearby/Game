using System;
using AnimationEvent;
using DefaultNamespace;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Timer ReloadTimer;
    
    protected  AttackAnimationEvent AttackAnimationEvent;

    protected virtual void Awake()
    {
        AttackAnimationEvent = GetComponentInParent<AttackAnimationEvent>();
    }


    public virtual bool TryAttack()
    {
        if (ReloadTimer.IsOver() == false)
        {
            return false;
        }
        
        return true;
    }
    
    
}


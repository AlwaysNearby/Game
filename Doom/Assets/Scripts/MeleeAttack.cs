using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAttackOption
{
    public void Charge(float dmg, Collider target)
    {
        var decrease = target.GetComponent<IDecrease>();
        if(decrease != null)
        {
            decrease.DecreaseHealth(dmg);
        }
    }
}

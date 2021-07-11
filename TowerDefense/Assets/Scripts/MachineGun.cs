using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : AttackTower
{

    

    public override void Shoot(Unit target)
    {
        if (Attack.AttemptShoot())
        {
            Attack.DamageTo(target.Health);
        }
        
        base.LookAt(target);
    }

    
  
    
    
    
    
    
}

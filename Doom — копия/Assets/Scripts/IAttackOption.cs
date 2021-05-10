using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackOption
{

    void Charge(float dmg, Collider target);
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : ProjectileWeapon
{
    public override void ShotTowards(Vector3 point)
    {
        AddShot(point);
        
    }
}

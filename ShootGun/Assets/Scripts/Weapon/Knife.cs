using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void ShotTorwads(Vector3 point)
    {
        if(TryShot())
        {
            Shot(point);
        }
    }

}

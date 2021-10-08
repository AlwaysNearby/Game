using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void ShotTorwads(Vector3 position)
    {
        if (TryShot())
        {
            Shot(position);
        }
    }
}

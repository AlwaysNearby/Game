using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    private const float _deegresInACircle = 360f; 

    protected override void Awake()
    {
        base.Awake();
    }

    public override void ShotTorwads(Vector3 point)
    {
        if (TryShot())
        {
            int numberOfTuples = Random.Range(3, 6);
            Vector3 offset = Vector3.up;
            float angleStep = _deegresInACircle / numberOfTuples;
            Quaternion rotation = Quaternion.Euler(0, 0, angleStep);

            Shot(point);

        }

    }
}

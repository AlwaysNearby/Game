using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void ShotTorwads(Vector3 position)
    {
        if (TryShot())
        {
            int numberOfTuples = Random.Range(1, 6);

            Shot(position);

            for (int i = 0; i < numberOfTuples; i++)
            {
                Vector3 randomPointOnSphere = Random.insideUnitSphere * 1.5f;
                Shot(position + randomPointOnSphere);
            }
        }
    }
}

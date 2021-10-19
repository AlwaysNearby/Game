using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : ProjectileWeapon
{
    private const float _deegresInACircle = 360f; 
    
    public override void ShotTowards(Vector3 point)
    {
        int numberOfTuples = Random.Range(3, 6);

        int numberOfPoints = numberOfTuples + 1;
        
        Vector3[] points = new Vector3[numberOfPoints];
        Vector3 offset = Vector3.up;
        Quaternion rotation = Quaternion.Euler(0, 0, _deegresInACircle / numberOfTuples);

        for (int i = 0; i < numberOfTuples; i++)
        {
            points[i] = point + offset;
            offset = rotation * offset;
        }

        points[numberOfPoints - 1] = point;
        
        AddShot(points);
    }
}

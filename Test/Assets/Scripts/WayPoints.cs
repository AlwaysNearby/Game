using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    private Transform[] _points;


    public Transform[] Points => _points;


    private void Awake()
    {
        _points = new Transform[transform.childCount];
        
        for (var i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    
}

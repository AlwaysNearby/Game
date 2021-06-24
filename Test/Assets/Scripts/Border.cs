using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Border : MonoBehaviour
{
    [SerializeField] private CountObstacle _countObstacle;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>() != null)
        {
            _countObstacle.Increase();
        }
    }
}

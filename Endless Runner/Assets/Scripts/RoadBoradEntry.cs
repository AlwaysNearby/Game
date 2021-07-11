using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBoradEntry : MonoBehaviour
{

    public event Action OnEntryCar;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            OnEntryCar?.Invoke();
        }
    }
}

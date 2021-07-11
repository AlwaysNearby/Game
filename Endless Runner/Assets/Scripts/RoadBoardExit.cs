using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBoardExit : MonoBehaviour
{ 
    public event Action OnExitCar;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            OnExitCar?.Invoke();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;


public enum TowerType
{
    MachineGun,
    RocketLauncher,
    Repairer,
}




public class PlaceForTower : MonoBehaviour
{
    [SerializeField] private TowerType _placeType;
    private Tower _currentTower;

    private void Start()
    {
        _currentTower = null;
    }


    public void ToPut(Tower tower)
    {
        if(tower.Type != _placeType || _currentTower != null)
            return;

        _currentTower = Instantiate(tower, transform.position, quaternion.identity);
    }

    
}

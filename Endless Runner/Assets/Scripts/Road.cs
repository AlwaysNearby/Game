using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    [SerializeField] private RoadBoardExit _roadExit;
    [SerializeField] private RoadBoradEntry _roadEntry;

    private Map _map;
    private Road _previousRoad;


    public int sizeRoad;


    private void Awake()
    {
        _map = FindObjectOfType<Map>().GetComponent<Map>();
    }


    private void OnEnable()
    {
        _roadEntry.OnEntryCar += _map.AddRoad;
    }

    private void OnDisable()
    {
        _roadExit.OnExitCar += _map.DeleteRoad;
    }


    public Road PreviousRoad
    {
        get => _previousRoad;

        set
        {
            if (value.GetType() == typeof(Road))
            {
                _previousRoad = value;
            }
          
          
        }
    }
}

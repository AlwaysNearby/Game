using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    [SerializeField] private List<Road> _currentRoads;
    [SerializeField] private Road[] _allVariantRoads;
    
    
    
    
    void Start()
    {
        for (var i = 1; i < _currentRoads.Count; i++)
        {
            _currentRoads[i].PreviousRoad = _currentRoads[i - 1];
        }
        
    }


    public void AddRoad()
    {
        
    }


    public void DeleteRoad()
    {
        
    }
    
}

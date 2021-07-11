using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{


    [SerializeField] private Transform[] _allPoints;

    public Way GetWayFor(Unit unit)
    {
        return unit.LeadTheWay(_allPoints);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{


    [SerializeField] private Transform[] _points;

    public Transform[] Points
    {
        get => _points;
        private set { ; }
    }
}

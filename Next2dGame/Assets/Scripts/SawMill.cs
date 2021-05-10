using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMill : Build
{

    [SerializeField] private List<Forester> _currentWorkers = new List<Forester>();

    [SerializeField] private Forester _worker;



    private void Start()
    {
        
    }



}

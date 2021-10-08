using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Ammo
{
    [SerializeField] private int _numberOfShots;

    private int _current—ount;

    public int CurrentCount => _current—ount;
    public void Init()
    {
        _current—ount = _numberOfShots;
    }

    public void Reduce()
    {
        _current—ount -= 1;
    }
    
    public void Fill()
    {
        _current—ount = _numberOfShots;
    }
}

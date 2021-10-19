using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Ammo
{
    private int _numberOfShots;
    private int _currentCount;


    public Ammo(int countShot)
    {
        _numberOfShots = _currentCount = countShot;
    }
    
    public int CurrentCount => _currentCount;

    public void Reduce()
    {
        _currentCount -= 1;
    }
    
    public void Fill()
    {
        _currentCount = _numberOfShots;
    }
}

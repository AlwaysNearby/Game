using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountObstacle : MonoBehaviour
{

    private Text _numberOfFallenObstacles;
    private int _count;

    
    void Start()
    {
        _numberOfFallenObstacles = GetComponent<Text>();
        _count = 0;
        _numberOfFallenObstacles.text = _count.ToString();
    }



    public void Increase()
    {
        _count++;
        View(_count);
    }




    private void View(int count)
    {
        _numberOfFallenObstacles.text = _count.ToString();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{

   [SerializeField] private int _cost;


   
    public int Cost
    {
        get
        {
            return _cost;
        }
    }



    public void ShowColoFromPlace(Color colorBuild)
    {
        var sprite = GetComponent<SpriteRenderer>();
        sprite.color = colorBuild;
    }




    





}

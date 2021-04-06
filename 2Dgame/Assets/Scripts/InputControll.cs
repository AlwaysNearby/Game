using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControll : MonoBehaviour
{


    private Camera _mainCamera;



    public InputControll()
    {
        _mainCamera = Camera.main;
    }


    public Vector3 Direction
    {
        get
        {
            return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        }
    }



    public Vector3 PosMouse
    {
        get
        {
            return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }





    
   
}

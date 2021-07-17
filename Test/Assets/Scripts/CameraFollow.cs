using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Vector3 _offset;

    private Player _target;
    
    
    void Start()
    {
        _target = FindObjectOfType<Player>();
    }

    private void LateUpdate()
    {
        transform.position = _target.transform.position + _offset;
      
    }




    
}

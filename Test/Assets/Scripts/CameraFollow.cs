using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    private Player _target;


   

    void Start()
    {
        _target = FindObjectOfType<Player>();
        _camera.Follow = _target.transform;
        _camera.LookAt = _target.transform;

    }

    




    
}

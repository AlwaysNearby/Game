using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMelt : MonoBehaviour
{

    [SerializeField] GameObject Vent;
    private float ReloadTime = 0.25f;
    private float Reload = 0.0f;
    private float speedVent = 40.0f;
    private float speed = 0f;


    void Start()
    {
        
    }

    void Update()
    {

        if(Reload <= 0)
        {

            Reload = ReloadTime;
            speed = (speed + speedVent) % 360;
            Vent.transform.localRotation = Quaternion.Euler(0, 0, speed);

        }
        else
        {
            Reload -= Time.deltaTime;
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody _rigidbody;
    private Vector3 direction;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        direction = Vector3.zero;
    }


    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                direction = Vector3.forward * hit.point.z * _force;
            }
            
        }
        else
        {
            direction = Vector3.zero;
        }
    }


    private void FixedUpdate()
    {
        _rigidbody.AddForce(direction * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Transform _follow;

    private Ray _ray;
    private Camera _mainCamera;
    Plane _plane;
    float _distToPlane;
    Vector3 _lastPos;

    void Start()
    {
        _mainCamera = Camera.main;
        _plane = new Plane(Vector3.forward, 1);
        _lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (_plane.Raycast(_ray, out _distToPlane))
        {
            transform.position = Vector3.MoveTowards(transform.position, _ray.GetPoint(_distToPlane), Time.deltaTime * 3f);

            transform.LookAt(_ray.GetPoint(_distToPlane));
        }


    }
}

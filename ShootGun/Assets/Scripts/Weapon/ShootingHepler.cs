using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHepler : MonoBehaviour
{   
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public Vector3 ÑonvertingPixelCoordinates(Vector2 point)
    {
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(point);
        Physics.Raycast(ray, out hit);

        return hit.point;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHepler : MonoBehaviour
{
    [SerializeField] private LayerMask _availableTarget;
    [SerializeField] private LayerMask _ignoreCollider;

    private Camera _mainCamera;
    //private RaycastHit _hit;
    private Plane _hitArea;
    private float _distanceToPlane;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _hitArea = new Plane(Vector3.up, Vector3.zero);
    }

    public Vector3 СonvertingPixelCoordinates(Vector2 point)
    {
        Ray ray = _mainCamera.ScreenPointToRay(point);

        if (Physics.Raycast(ray, float.MaxValue, _ignoreCollider))
        {
            return Vector3.zero;
        }

        /* if (Physics.Raycast(ray, out _hit, float.MaxValue, _availableTarget))
        {
            return _hit.point;
        }
        */

        if (_hitArea.Raycast(ray, out _distanceToPlane))
        {
            return ray.GetPoint(_distanceToPlane);
        }
        

        return Vector3.zero;
    }
}

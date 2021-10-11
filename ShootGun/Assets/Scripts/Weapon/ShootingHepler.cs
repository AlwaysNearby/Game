using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHepler : MonoBehaviour
{
    [SerializeField] private List<LayerMask> _availableTargets;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public Vector3 ÑonvertingPixelCoordinates(Vector2 point)
    {
        Ray ray = _mainCamera.ScreenPointToRay(point);
        RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction);

        foreach (var hitInfo in hits)
        {
            if (CheckCollider(hitInfo.collider))
            {
                return hitInfo.point;
            }
        }

        return Vector3.zero;
    }


    private bool CheckCollider(Collider collider)
    {
        int layer = collider.gameObject.layer;

        int layerMask = (int)Mathf.Pow(2, layer);

        foreach(var ignoreMask in _availableTargets)
        {
            if(layerMask.Equals(ignoreMask.value))
            {
                return true;
            }
        }

        return false;
    }
}

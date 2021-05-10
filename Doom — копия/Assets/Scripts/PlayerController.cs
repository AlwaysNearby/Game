using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform plane;
    public float speedRotate = 5f;
    public LayerMask battleArea;



    private Camera _mainCamera;
    private Gun _gun;
    



    void Start()
    {
        _mainCamera = Camera.main;
        _gun = FindObjectOfType<Gun>();
    }


    private void FixedUpdate()
    {
        LookAt(Input.mousePosition, plane);

    }
    private void LookAt(Vector2 mousePosition, Transform plane)
    {
        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, battleArea))
        {
            var direction = hit.point - transform.position;
            var angle = Mathf.Atan2(direction.z, direction.x) * 180 / Mathf.PI;
            Quaternion quaternion = Quaternion.Euler(0, -angle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, Time.deltaTime * speedRotate);
            _gun.Rotate(direction.magnitude, -angle);
            _gun.CurrentFiringPoint = direction;
        }
    }
}

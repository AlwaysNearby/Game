using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class Rocket : MonoBehaviour
{


    public event Action<Unit> OnEnterUnit;
    
    
    [SerializeField] private float _speed;
    private Unit _target;


    public Unit Target
    {
        get => _target;

        set
        {
            _target = value;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        var targetPosition = _target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);
        LookAt(targetPosition - transform.position);

    }
    

    private void LookAt(Vector2 direction)
    {
        var angleInDegrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleInDegrees);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Unit>() != null)
        {
            OnEnterUnit?.Invoke(_target);
            Destroy(this.gameObject);
        }
        
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopingDistance;
    [SerializeField] private LayerMask _obstacle;


    [SerializeField] protected readonly Weapon Weapon;

    protected virtual void Awake()
    {
        
    }


    public bool TryMove(Vector3 direction)
    { 
        if(Physics.Raycast(transform.position, direction, _stopingDistance, _obstacle))
        {
            return false;
        }

        return true;
    }

    public void Move(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction * _speed, _speed * Time.deltaTime);
    }
}

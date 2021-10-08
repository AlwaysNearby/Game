using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ShotHandler))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;
    private ShotHandler _handler;

    private void Awake()
    {
        _handler = GetComponent<ShotHandler>();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position  +  _direction * _speed, Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        _handler.Handle(other);
    }
}

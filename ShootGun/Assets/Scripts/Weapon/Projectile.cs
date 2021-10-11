using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ShotHandler))]
public class Projectile : MonoBehaviour
{
    public Vector3 Direction { private get; set; } = Vector3.zero;

    [SerializeField] private float _speed;

    private ShotHandler _handler;

    private void Awake()
    {
        _handler = GetComponent<ShotHandler>();
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position  +  Direction * _speed, Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        _handler.Handle(other);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _normalizedDirection;
    private float _speed;
    private float _lifeTime = 5f;


    private void Start()
    {
        _speed = 10.0f;
        Destroy(this.gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _normalizedDirection * _speed, Time.deltaTime * _speed);
    }




    public void SetDirection(Vector3 direction)
    {
        _normalizedDirection = direction.normalized;
    }


}

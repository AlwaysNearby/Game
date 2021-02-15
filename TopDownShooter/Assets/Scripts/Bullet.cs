using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{



    private Vector3 _directionBullet;
    private bool _shotIsEnemy;

    [SerializeField] private float _speed;

    void Start()
    {
        Destroy(this.gameObject, 5f);
        _speed = 7.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _directionBullet, _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction, bool isEnemy)
    {
        _directionBullet = direction.normalized;
        _directionBullet.z = 0;
        _shotIsEnemy = isEnemy;
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(_directionBullet.y, _directionBullet.x) * 180 / Mathf.PI);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Enemy : MonoBehaviour
{

    private GameObject _target;

    private GameObject _mainTarget;


    public virtual void Start()
    {
        _target = _mainTarget = GameObject.FindGameObjectWithTag("MainTarget");
    }


    private void TurnToTarget(Vector2 direction)
    {
        var angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    public void Move(float speed)
    {
        if (_target != null)
        {
            var direction = (_target.transform.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction * speed, Time.deltaTime * speed);
            TurnToTarget(new Vector2(direction.x, direction.y));
        }
    }





  

    public abstract GameObject ChoiceOfTarget(Collider2D[] colliders);


    public virtual void ChangeTarget(GameObject currentTarget)
    {
        if (currentTarget == null)
            _target = _mainTarget;
        else
        {
            _target = currentTarget;
        }
    }



}

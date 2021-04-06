using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Enemy : MonoBehaviour
{

    private GameObject _target;

    private GameObject _mainTarget;



    public virtual void Start()
    {
        this._target = this._mainTarget = GameObject.FindGameObjectWithTag("MainTarget");
    }



    public void TurnToTarget()
    {
        if (_target != null)
        {
            var direction = _target.transform.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }


    public void Move(float speed)
    {
        if (_target != null)
        {
            var direction = (_target.transform.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction * speed, Time.deltaTime * speed);
        }
    }

    public virtual GameObject ChoiceOfTarget(Collider2D[] colliders, IComparer comparer, float epsilon)
    {
        var currentDistance = epsilon;
        var target = -1;
        for(var i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].tag != "Zombie" && colliders[i].tag != "Bullet")
            {
                var distance = Vector3.Distance(transform.position, colliders[i].transform.position);
                if(comparer.CheckDistance(currentDistance, distance))
                {
                    target = i;
                    currentDistance = distance;

                }
            }
        }


        if (target == -1)
            return null;

        return colliders[target].gameObject;
    }



    public GameObject GetTarget()
    {
        return _target;
    }

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

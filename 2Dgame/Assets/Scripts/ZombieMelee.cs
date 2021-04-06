using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ZombieMelee : Enemy
{
    [SerializeField] private float _speed;


    private float _timeToChangeTarget;
    private float _lastTimeChangeTarget;




    public override void Start()
    {
        _lastTimeChangeTarget = 0f;
        _timeToChangeTarget = 2.5f;
        base.Start();
    }



    private void Update()
    {
        Move(_speed);
    }

    private void FixedUpdate()
    {
        
        var collider = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 2.5f);

        if(collider != null && Time.time - _lastTimeChangeTarget >= 0)
        {
            ChangeTarget(ChoiceOfTarget(collider));
            _lastTimeChangeTarget = Time.time + _timeToChangeTarget;
        }
        
        
    }

 



    public override void ChangeTarget(GameObject currentTarget)
    {
        base.ChangeTarget(currentTarget);
    }

    public override GameObject ChoiceOfTarget(Collider2D[] colliders)
    {
        var minDistance = float.MaxValue;
        var target = -1;
        for(var i = 1; i < colliders.Length; i++)
        {
            if (colliders[i].tag != "Zombie" && colliders[i].tag != "Bullet")
            {
                var currentDistance = Vector3.Distance(transform.position, colliders[i].transform.position);

                if (currentDistance < float.Epsilon)
                    break;

                if (minDistance > currentDistance)
                {
                    minDistance = currentDistance;
                    target = i;
                }
            }
        }

        if(target == -1)
        {
            return null;
        }

        return colliders[target].gameObject;
    }
}

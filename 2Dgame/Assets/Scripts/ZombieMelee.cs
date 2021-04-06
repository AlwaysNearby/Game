using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ZombieMelee : Enemy, IComparer
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
        TurnToTarget();
    }

    private void FixedUpdate()
    {
        
        var collider = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 2.5f);

        if(collider != null && Time.time - _lastTimeChangeTarget >= 0)
        {
            ChangeTarget(ChoiceOfTarget(collider, this, float.MaxValue));
            _lastTimeChangeTarget = Time.time + _timeToChangeTarget;
        }
        
        
    }

    public override void ChangeTarget(GameObject currentTarget)
    {
        base.ChangeTarget(currentTarget);
    }

    public override GameObject ChoiceOfTarget(Collider2D[] colliders, IComparer comparer, float epsilon)
    {
       return base.ChoiceOfTarget(colliders, comparer, epsilon);
    }

    public bool CheckDistance(float last, float current)
    {
        return last > current;
    }
}

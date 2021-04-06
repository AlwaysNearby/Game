using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ZombieSoldier : Enemy, IComparer
{


    [SerializeField] private Weapon[] _armory = new Weapon[3];
    [SerializeField] private AnimationController _animState;
    private Weapon _currentWeapon;

    private float _speed = 1f;
    private bool _canMove = true;
    private bool _canShoot = false;
    private float _timeToChangeTarget;
    private float _lastTimeChangeTarget;

    public override void Start()
    {
        _lastTimeChangeTarget = 0f;
        _timeToChangeTarget = 2.5f;
        _currentWeapon = _armory[Random.Range(0, _armory.Length)];
        base.Start();
    }




    private void Update()
    {
        if(_canMove)
             Move(_speed);
        if(_canShoot)
        {
            Shoot();
        }


        TurnToTarget();

    }



    private void FixedUpdate()
    {
        var collider = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 5f);

        var colliderToShoot = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 2.5f);

        if(Check(colliderToShoot))
        {
            _canMove = false;
            _canShoot = true;
        }


        if (collider != null && Time.time - _lastTimeChangeTarget >= 0)
        {
            ChangeTarget(ChoiceOfTarget(collider, this, float.MinValue));
            _lastTimeChangeTarget = Time.time + _timeToChangeTarget;
        }
    }


    private void Shoot()
    {

        if (GetTarget() == null)
            return;


        if(_animState.StateAnimation("Reload"))
        {
            _currentWeapon.Shoot(GetTarget().transform.position, transform.position);
        }
    }


    private bool Check(Collider2D[] allCollider)
    {
        var currentTarget = GetTarget();

        if (currentTarget == null)
            return false;


        if (Vector3.Distance(transform.position, currentTarget.transform.position) > 2.5f)
            return false;

        for(var i = 0; i < allCollider.Length; i++)
        {
            if(allCollider[i].tag == currentTarget.tag)
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckDistance(float last, float current)
    {
        return last < current;
    }
}

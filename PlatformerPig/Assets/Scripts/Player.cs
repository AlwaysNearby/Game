using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float SpeedWalk, SpeedJump;
    public LayerMask WhatIsGround;
    public Transform IsGround;
    public AnimationClip attackAnimation;



    private Rigidbody2D rigidbody;
    private Animator _animatorController;
    private float _direction, _lastAttack = 0f, _attackColdown = 0.75f;
    private bool _canJump = false, _canAttack = true;


    public void Attack()
    {
        if(_canAttack && Time.time - _lastAttack >= 0)
        {
            _canAttack = false;
            _lastAttack = Time.time + _attackColdown;
            StartCoroutine(StartAttack(attackAnimation.length));
        }
    }

    public void Move(float direction)
    {
        if(direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        _direction = direction;
    }


    public void Jump()
    {
        if(CheckGround())
        {
            rigidbody.AddForce(Vector2.up * SpeedJump, ForceMode2D.Impulse);
            _canJump = true;
        }

    }


    private void Update()
    {
        

    }

    private void FixedUpdate()
    {
        if (_direction != 0)
        {
            rigidbody.velocity = new Vector2(Vector2.right.x * SpeedWalk * _direction, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
        }

        if (_canJump)
        {
            if (CheckGround() && rigidbody.velocity.y == 0)
            {
                _canJump = false;
            }

            _animatorController.SetFloat("SpeedY", rigidbody.velocity.y);
            _animatorController.SetBool("CanJump", _canJump);
        }

        _animatorController.SetFloat("Walk", Mathf.Abs(_direction));
    }


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
    }



    private IEnumerator StartAttack(float lengthAnim)
    {
        _animatorController.SetBool("attack",!_canAttack);
        yield return new WaitForSeconds(lengthAnim);
        _canAttack = true;
        _animatorController.SetBool("attack",!_canAttack);
    }

    private bool CheckGround()
    {
        var ground = Physics2D.OverlapCircleAll(IsGround.position, 0.05f, WhatIsGround);
        if(ground.Length > 0)
        {
            return true;
        }

        return false;
        
    }
}

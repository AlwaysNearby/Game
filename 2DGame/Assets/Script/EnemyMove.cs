using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Transform Lineofight;
    public Transform CanAttack;
    public float RadiusLine;
    public float RadiusAttack;
    public LayerMask _target;
    public Transform Player;
    public float speed = 3.0f;
    private Animator _anim;
    private Rigidbody2D _rb;
    private int direc;
    private float Reload;
    private float ReloadTime;
    private bool idle;




    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        Reload = 0f;
        ReloadTime = 2.5f;
        idle = false;
    }


    void Update()
    {
        if (Reload <= 0 && !IsPlayingHitAnim("hit"))
        {
            Collider2D _player = Physics2D.OverlapCircle(CanAttack.position, RadiusAttack, _target);
            if (_player != null)
            {
                var _attack = GetComponent<Attack>();
                _attack._Attack();
                Reload = ReloadTime;
            }
        }
        else
            Reload -= Time.deltaTime;
    }


    private bool IsPlayingHitAnim(string AnimName)
    {
        var stateAnimation = _anim.GetCurrentAnimatorStateInfo(0);
        if (stateAnimation.IsName(AnimName))
            return true;
        else
            return false;
    }


    private void FixedUpdate()
    {
        Collider2D[] _player = Physics2D.OverlapCircleAll(Lineofight.position, RadiusLine, _target);

        if (_player.Length != 0)
        {
            
            if (Player.position.x - transform.position.x > 1)
            {
                direc = 1;
                _rb.velocity = new Vector2(speed, _rb.velocity.y);
                idle = false;
            }
            else if(Player.position.x - transform.position.x < -1)
            {
                direc = -1;
                _rb.velocity = new Vector2(-speed, _rb.velocity.y);
                idle = false;

            }  
            else
            {
                _rb.velocity = new Vector2(0, 0);
                idle = true;
            }

        }
        else
        {
            _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            direc = -1;
            idle = false;
        }
        Flip(direc);
        _anim.SetBool("Idle", idle);
        
    }



    void Flip(int direction)
    {
        if (direction > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Lineofight.position, RadiusLine);
        Gizmos.DrawWireSphere(CanAttack.position, RadiusAttack);

    }
}


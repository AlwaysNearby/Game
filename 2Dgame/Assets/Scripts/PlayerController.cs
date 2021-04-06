using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private InputControll _inputPlayer;
    [SerializeField]private Weapon[] _armory = new Weapon[3];
    private Weapon _currentWeapon;

    [SerializeField] private AnimationController _animState;


    public SwitchWeaponEvent OnSwintch;


    [SerializeField]
    private float _speed;



    void Start()
    {
        _inputPlayer = new InputControll();
        _currentWeapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        Shoot();

        if(Input.GetKeyDown(KeyCode.Q) && _animState.StateAnimation("Reload"))
        {
            OnSwintch.Invoke(_currentWeapon.GetWeapon());
            _currentWeapon.SwitchWeapon(_armory);
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _armory[_currentWeapon.GetWeapon()].Shoot(_inputPlayer.PosMouse, transform.position);
        }
    }

    private void Move()
    {
        var currentPos = transform.position;
        var delta = Vector3.MoveTowards(currentPos, currentPos + _inputPlayer.Direction, Time.deltaTime * _speed);
        transform.position = delta;
    }



    private void Flip()
    {
        var direction = _inputPlayer.PosMouse - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
   
}

[System.Serializable]
public class SwitchWeaponEvent : UnityEvent<int> { }
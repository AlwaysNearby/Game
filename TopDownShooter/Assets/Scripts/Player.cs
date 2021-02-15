using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject soldierPlayer;

    private InputControl _input;
    private float _speed;

    private Vector3 _deltaMove;

    private Vector3 _endPos;
    private Vector3 _startPos;

    private Animator _animatorController;

    private float _timeReload;

    [SerializeField] private bool _canShoot;

    void Start()
    {
        _input = new InputControl();
        _speed = 3.0f;
        _deltaMove = new Vector3(0, 0, 0);
        _startPos = transform.position;
        _endPos = transform.position;
        _animatorController = GetComponent<Animator>();
        _timeReload = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        _deltaMove = new Vector3(_input.MoveX(), _input.MoveY(), 0) * _speed;
        _startPos = transform.position;
        _endPos = transform.position + _deltaMove;
        transform.position = Vector3.MoveTowards(_startPos, _endPos, Time.deltaTime * _speed * 0.5f);

        
       
        ChangePlayerStateAnimation(Mathf.Abs(_input.MoveX()), Mathf.Abs(_input.MoveY()));
        Flip();
        if(_canShoot)
        {
            if (Time.time - _timeReload > 0.35f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var newWeapon = GetComponent<Weapon>();
                    newWeapon.CreateBullet(Input.mousePosition, transform.position);
                    _timeReload = Time.time;
                }
            }
        }
    }

    void ChangePlayerStateAnimation(float _directionX, float _directionY)
    {
        if (!_canShoot)
        {
            if (_directionX > 0 || _directionY > 0)
            {
                _animatorController.SetBool("Run", true);
            }
            else
            {
                _animatorController.SetBool("Run", false);
            }
        }
        else
        {

        }

    }

    void Flip()
    {
        var positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var posPlayer = transform.position;
        var differencePos = positionMouse - posPlayer;
        var angleRotation = Mathf.Atan2(differencePos.y, differencePos.x);
        angleRotation = angleRotation * 180/Mathf.PI;
        transform.rotation = Quaternion.Euler(0,0, angleRotation);


    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Gun")
        {
            var posPlayer = transform.position;
            Instantiate(soldierPlayer, posPlayer, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }
    }
   
}

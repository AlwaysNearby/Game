using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    private float angleSpeed;
    private float angle;
    private float currentTime;
    private float _angleTime;
    private Vector3 _endPos;
    private Vector3 _startPos;
    private float distance;
    private float _totalTime;
    private float _lastTime;
    private Quaternion start;
    private Quaternion end;

    public float dmg;
    public float speed;
    

    private GameObject _target;

    private void Start()
    {
        angleSpeed = Random.Range(10, 41);
        start = Quaternion.identity;
        _target = GameObject.Find("PlayerShip");
        _endPos = _target.transform.position;
        _startPos = transform.position;
        currentTime = 0f;
        speed = Random.Range(1, 5);
        distance = Vector3.Magnitude(_endPos - _startPos);
        _totalTime = distance / speed;
        _lastTime = Time.time;
        end = Quaternion.Euler(0, 0, 180);
        _angleTime = 180 / Random.Range(50, 61);

        
        

    }

    void Update()
    {

        transform.position = Vector3.Lerp(_startPos, _endPos, currentTime / _totalTime);
        transform.rotation = Quaternion.SlerpUnclamped(start,end,currentTime/_angleTime);
        currentTime = Time.time - _lastTime;
        
    }


  



}

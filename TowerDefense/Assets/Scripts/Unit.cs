using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Way
{
    private readonly Transform[] _wayPoints;
    private int _pointNumberOnTheWay = 0;

    public Way(Transform[] wayPoints)
    {
        _wayPoints = wayPoints;
    }
    
    
    public Vector2 CurrentPoint
    {
        get
        {
            return _wayPoints[_pointNumberOnTheWay].position;
        }
        
        private set { ; }
    
    }
    public Vector2 EndPoint
    {
        get
        {
            return _wayPoints[_pointNumberOnTheWay + 1].position;
        }

        private set { ; }

    }

    public void SetNewPoints()
    {

        if (IsNotEndPoint(_pointNumberOnTheWay))
        {
            _pointNumberOnTheWay += 1;
        }
        
    }



    private bool IsNotEndPoint(int numberPoint)
    {
        return numberPoint < _wayPoints.Length - 2;
    }


}

public abstract class Unit : MonoBehaviour
{

    private Way _way;
    [SerializeField] private float _speed;
    private float _time;
    private float _lastTime;
    private float _totalTime;
    private IHealth _health;




    public IHealth Health
    {
        get => _health;

        private set { ; }
    }
    


    private void Start()
    {
        _time = 0f;
        _lastTime = 0f;
        _way = new Way(FindObjectOfType<WayPoints>().GetComponent<WayPoints>().Points);
        _totalTime = CalculateTimeinWay(_way.CurrentPoint, _way.EndPoint, out _totalTime);
        _health = GetComponent<IHealth>();
        LookAt(_way.EndPoint - _way.CurrentPoint);
    }


    public virtual void Move()
    {
        transform.position = Vector3.Lerp(_way.CurrentPoint, _way.EndPoint, _time / _totalTime);
        _time = Time.time - _lastTime;
        if (transform.position.Equals(_way.EndPoint))
        {
            _way.SetNewPoints();
            _time = 0f;
            _lastTime = Time.time;
            CalculateTimeinWay(_way.CurrentPoint, _way.EndPoint, out _totalTime);
            LookAt(_way.EndPoint - _way.CurrentPoint);
        }


    }

    private float CalculateTimeinWay(Vector2 currentPoint, Vector2 endPoint, out float totalTime)
    {
        float distance = (_way.EndPoint - _way.CurrentPoint).magnitude;
        return totalTime = distance / _speed;
    }

    private void LookAt(Vector2 direction)
    {
        var angleInDegrees = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, angleInDegrees);
    }
    

}

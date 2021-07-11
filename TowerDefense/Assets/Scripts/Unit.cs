using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


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

public enum UnitType
{
    Infantry,
    Aviation,
    
    
}

public abstract class Unit : MonoBehaviour
{
    public IHealth Health
    {
        get => _health;

        private set { ; }
    }
    public UnitType Type
    {
        get => _unitType;
        private set { ; }
    }
    
    [SerializeField] private float _speed;
    [SerializeField] private int _cost;
    [SerializeField] private UnitType _unitType;
    [SerializeField] private string _namePoints;
    
    private Way _way;
    private float _time;
    private float _lastTime;
    private float _totalTime;
    private IHealth _health;
    

    private void Awake()
    {
        _health = GetComponent<Health>();
        _way = FindObjectOfType<WayPoints>().GetComponent<WayPoints>().GetWayFor(this);
    }

    private void Start()
    {
        _time = 0;
        _lastTime = Time.time;
        _totalTime = CalculateTimeinWay(_way.CurrentPoint, _way.EndPoint, out _totalTime);
        LookAt(_way.EndPoint - _way.CurrentPoint);

        _health.OnDeath += () =>
        {
            Balance.Instance.Increase(_cost);
            Destroy(this.gameObject);
        };

    }

    private void OnEnable()
    {
        _health.OnDeath += FindObjectOfType<Wave>().GetComponent<Wave>().DecreaseNumberUnits;
    }
    
    private void OnDisable()
    {
        _health.OnDeath -= FindObjectOfType<Wave>().GetComponent<Wave>().DecreaseNumberUnits;
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


    public Way LeadTheWay(Transform[] allPoints)
    {
        List<Transform> resultWay = new List<Transform>();

        foreach (var point in allPoints)
        {
            if (point.tag.Equals(_namePoints))
            {
                var randomPoints = point.GetChild(Random.Range(0, point.childCount));


                for (var i = 0; i < randomPoints.childCount; i++)
                {
                    resultWay.Add(randomPoints.GetChild(i));
                }
                
                break;

            }
            
        }
        return new Way(resultWay.ToArray());
    }
}

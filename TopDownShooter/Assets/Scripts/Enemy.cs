using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Enemy : MonoBehaviour
{

    private int counterPoint;
    private float _speed;
    private float _lastTime;
    private Transform _startPos;
    private Transform _endPos;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private GameObject[] _wayPoints;
    
    void Start()
    {
        counterPoint = 0;
        _speed = Random.Range(1, 4);
        _startPos = _wayPoints[counterPoint].transform;
        _endPos = _wayPoints[counterPoint + 1].transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        if (Vector3.Distance(transform.position,_endPos.position) < float.Epsilon)
        {
            if (counterPoint < _wayPoints.Length - 2)
            {
                counterPoint++;
                
            }
            _startPos = _wayPoints[counterPoint].transform;
            _endPos = _wayPoints[counterPoint + 1].transform;
            

        }
        else
        {
            var difference = Vector3.MoveTowards(_startPos.position, _endPos.position, Time.deltaTime * _speed);
            rigidbody2D.MovePosition(difference);
            _startPos.position = difference;
            

        }

        if(transform.position.Equals(_wayPoints[_wayPoints.Length - 1].transform.position))
        {
            ReverseWay(_wayPoints);
            counterPoint = 0;

        }

    }


    void ReverseWay(GameObject[] way)
    {
        for(int i = 0, j = way.Length - 1; i < j; i++, j--)
        {
            var temp = way[i];
            way[i] = way[j];
            way[j] = temp;
        }
    }
}

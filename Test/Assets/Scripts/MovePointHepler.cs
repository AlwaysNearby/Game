using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointHepler : MonoBehaviour
{
    private Transform[] _wayPoints;
    private int _currentPosition;
    
    public event Action OnEntryEndPoint;
    public event Action OnFinish;



    private void Start()
    {
        _currentPosition = 0;
        _wayPoints = FindObjectOfType<WayPoints>().GetComponent<WayPoints>().Points;
        transform.position = _wayPoints[_currentPosition].position;
        transform.LookAt(_wayPoints[_currentPosition + 1]);
    }


    public void Move(float speed)
    {
        StartCoroutine(Movement(speed));
    }



    private IEnumerator Movement(float speed)
    {
        Vector3 endPoint = _wayPoints[_currentPosition + 1].position;
        transform.LookAt(endPoint);
        while (Vector3.Distance(transform.position, endPoint) > float.Epsilon)
        {
            
            var delta = Vector3.MoveTowards(transform.position, endPoint, Time.deltaTime * speed);
            transform.position = delta;
            yield return null;
        }

        _currentPosition += 1;
        if (_currentPosition == _wayPoints.Length - 1)
        {
            OnFinish?.Invoke();
        }
        
        OnEntryEndPoint?.Invoke();
    }
    
    
}

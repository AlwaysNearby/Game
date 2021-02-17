using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Enemy : MonoBehaviour
{
    class Way
    {
        public int startPos;
        public int endPos;

        public Way(int rnd)
        {
            startPos = rnd;
            endPos = startPos + Random.Range(1, 5);
        }
    }

    private int counterPoint;
    private float _speed;
    private Transform _endPos;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private GameObject[] _wayPoints;
    private Way way;
    
    void Start()
    {
        way = new Way(Random.Range(0, 6));

        counterPoint = way.startPos; ;
        _speed = Random.Range(0.5f, 2f);
        _endPos = _wayPoints[counterPoint].transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform.position = _endPos.position;
        print(way.startPos + " " + way.endPos);
        
    }


    private void Update()
    {

       
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _endPos.position) < 0.2f)
        {
            if (counterPoint < way.endPos)
            {
                counterPoint++;

            }
            _endPos = _wayPoints[counterPoint].transform;
            var direction = _endPos.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * 180/Mathf.PI;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            



        }
        else
        {
            var difference = Vector3.MoveTowards(transform.position, _endPos.position, Time.fixedDeltaTime * _speed);
            rigidbody2D.MovePosition(difference);



        }

        if (Vector3.Distance(transform.position, _wayPoints[way.endPos].transform.position) < 0.2f)
        {
            ReverseWay(_wayPoints, way.startPos, way.endPos);
            counterPoint = way.startPos;
            print("1");

        }
    }

    void ReverseWay(GameObject[] way, int min, int max)
    {
        for(int i = min, j = max; i < j; i++, j--)
        {
            var temp = way[i];
            way[i] = way[j];
            way[j] = temp;
        }
    }
}

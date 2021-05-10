using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    private Way way;
    private List<Transform> currentWay;

    private Vector3 direction;


    void Start()
    {

        currentWay = new List<Transform>();
        way = FindObjectOfType<Way>().GetComponent<Way>();
        var newWay = way.GetRandomWay();
        for(var i = 0; i < newWay.childCount; i++)
        {
            currentWay.Add(newWay.GetChild(i));
        }


        transform.position = currentWay[0].position;

        direction = (currentWay[1].position - transform.position).normalized;
    }

    void Update()
    {


        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{

    public Transform[] ways;



    public Transform GetRandomWay()
    {
        return ways[Random.Range(0, ways.Length)];
    }

    

   
}

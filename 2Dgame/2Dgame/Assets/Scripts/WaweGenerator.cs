using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweGenerator : MonoBehaviour
{
    private int count;
    private Queue<GameObject> _mobs = new Queue<GameObject>();


    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }




    public void CreateWawe(GameObject[] currentWawe)
    {
        for(var i = 0; i < count; i++)
        {
            _mobs.Enqueue(currentWawe[Random.Range(0, currentWawe.Length)]);
        }
    }



    public Queue<GameObject> GetWawe()
    {
        return _mobs;
    }




    

}

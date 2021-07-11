using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveLauncher : MonoBehaviour
{
    
    
    public void Initiate(Queue<Unit> units)
    {
        StartCoroutine(Run(units));
    }




    private IEnumerator Run(Queue<Unit> units)
    {
        while (units.Count > 0)
        {
            var unit = units.Dequeue();
            Instantiate(unit);


            yield return new WaitForSeconds(Random.Range(2f, 3f));

        }
    }
    
    
}

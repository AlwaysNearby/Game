using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forester : MonoBehaviour
{


    private GameObject _targetWork;
    

  

    public IEnumerator GoingToWork()
    {
        var direction = (_targetWork.transform.position - transform.position).normalized;

        while(Vector3.Distance(_targetWork.transform.position, transform.position) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime);
            yield return null;
        }

        StartCoroutine(Work());
    }




    public IEnumerator Work()
    {

        yield return null;
    }



    
}

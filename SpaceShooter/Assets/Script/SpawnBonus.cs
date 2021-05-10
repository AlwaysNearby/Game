using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    public GameObject[] _bonus;

    public GameObject[] _spawn;



    private int chance = 20;


    public IEnumerator NewBonus()
    {
        while(true)
        {
            if(Random.Range(15, 21) == chance)
            {
                Instantiate(_bonus[Random.Range(0, _bonus.Length)], _spawn[Random.Range(0, _spawn.Length)].transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(4f);
        }
    }
   
}

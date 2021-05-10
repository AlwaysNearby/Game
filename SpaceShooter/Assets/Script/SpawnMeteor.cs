using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject[] _around;
    public GameObject[] _spawn;


    public IEnumerator spawnMeteor()
    {
        while(true)
        {
            var meteor = Instantiate(_around[Random.Range(0, _around.Length)], _spawn[Random.Range(0, _spawn.Length)].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(1.5f);
        }
    }
 
}

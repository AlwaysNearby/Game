using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWawe : MonoBehaviour
{
    [SerializeField] private Transform[] _placeToSpawn;




    public IEnumerator WaweRelease(Queue<GameObject> currentWawe)
    {
        while(currentWawe.Count > 0)
        {
            Instantiate(currentWawe.Dequeue(), _placeToSpawn[Random.Range(0, _placeToSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f, 2.5f));
        }
    }


}

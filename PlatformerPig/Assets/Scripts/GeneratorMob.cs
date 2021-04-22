using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMob : MonoBehaviour
{
    public Door[] PlaceToSpawn;

    [SerializeField] private GameObject[] _mobs;

    void Start()
    {
        StartCoroutine(FindingPlaceToSpawn(PlaceToSpawn));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnMob(Transform posToSpawn)
    {
        Instantiate(_mobs[Random.Range(0, _mobs.Length)], new Vector3(posToSpawn.position.x, posToSpawn.position.y, 0), Quaternion.identity);
    }



    private IEnumerator FindingPlaceToSpawn(Door[] DoorToSpawn)
    {
        yield return new WaitForSeconds(2f);
        while(true)
        {
            var currentDoor = Random.Range(0, DoorToSpawn.Length);
            if (DoorToSpawn[currentDoor].CanExit)
            {
                DoorToSpawn[currentDoor].StartOpening();
            }


            yield return new WaitForSeconds(1F);
        }
    }
}

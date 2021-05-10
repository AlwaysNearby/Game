using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{



    private float interval;
    private float minInterval;
    private float maxInterval;

    

    public void SendMobsForWave(Queue<Enemy> enemies)
    {
        StartCoroutine(LaunchWave(enemies));
    }


    private IEnumerator LaunchWave(Queue<Enemy> currentWave)
    {
        minInterval = Random.Range(0f, 0.5f);
        maxInterval = Random.Range(0.75f, 1f);
        interval = Random.Range(minInterval, maxInterval);


        while(currentWave.Count > 0)
        {

            Instantiate(currentWave.Dequeue());

            yield return new WaitForSeconds(0.5f);
        }
    }

    
}

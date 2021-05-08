using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorWave : MonoBehaviour
{ 

    public Queue<Enemy> CreateWave(Enemy[] enemies, int count)
    {

        Queue<Enemy> wave = new Queue<Enemy>();

        for(var i = 0; i < count; i++)
        {
            wave.Enqueue(enemies[Random.Range(0, enemies.Length)]);
        }

        return wave;
    }

}

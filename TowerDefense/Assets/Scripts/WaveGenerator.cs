using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveGenerator
{ 
    
    private Unit[] _unitsVariant;


    public WaveGenerator(Unit[] unitsVariant)
    {
        _unitsVariant = unitsVariant;
    }



    public Queue<Unit> СreateWave(int quantity)
    {
        Queue<Unit> wave = new Queue<Unit>();
        for (int numberInTheQueue = 0; numberInTheQueue < quantity; numberInTheQueue++)
        {
            var unit = _unitsVariant[Random.Range(0, _unitsVariant.Length)];
            wave.Enqueue(unit);
        }

        return wave;

    }






}

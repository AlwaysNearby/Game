using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GeneratorWave _generator;
    
    void Start()
    {
        _generator.CreateWave(5);
    }
    
}

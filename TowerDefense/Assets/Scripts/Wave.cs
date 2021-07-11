using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Wave : MonoBehaviour
{

    [SerializeField] private Unit[] _allUnits;
    [SerializeField] private int _max;
    [SerializeField] private int _maxNumberUnits, _minNumberUnits;
    [SerializeField] private Text _countWave;
    

    private int _current;
    private WaveGenerator _waveGenerator;
    private WaveLauncher _launcher;
    private int numberUnitsinWave;
    
    
    
    
    public event Action OnWaveEnd;

    public int Current
    {
        get => _current;
        private set { ; }
    }


    private void Awake()
    {
        _waveGenerator = new WaveGenerator(_allUnits);
        _launcher = GetComponent<WaveLauncher>();
    }

    private void Start()
    {
        numberUnitsinWave = 0;
        _current = 1;
        UpdateAccountInUi();
    }


    public void Create()
    {
        if (_current > _max)
        {
            throw new ArgumentException();
        }
        
        if (numberUnitsinWave == 0)
        {
            numberUnitsinWave = Random.Range(_minNumberUnits, _maxNumberUnits + 1);
            var wave = _waveGenerator.СreateWave(numberUnitsinWave);
            _launcher.Initiate(wave);
            UpdateAccountInUi();
        }
    }


    public void DecreaseNumberUnits()
    {
        numberUnitsinWave -= 1;
        if (numberUnitsinWave <= 0)
        {
            OnWaveEnd?.Invoke();
            IncreaseCounter();
        }
        
    }



    private void IncreaseCounter()
    {
        _current += 1;
    }


    private void UpdateAccountInUi()
    {
        _countWave.text = "WAVE: " + _current.ToString() + "/" + _max.ToString();
    }


}

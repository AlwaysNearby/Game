using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    [SerializeField] private string _currentNameScene;

    private MovePointHepler _movePointHepler;


    private void Awake()
    {
        _movePointHepler = FindObjectOfType<MovePointHepler>().GetComponent<MovePointHepler>();
    }


    private void OnEnable()
    {
        _movePointHepler.OnFinish += ReloadLevel;
    }


    private void OnDisable()
    {
        _movePointHepler.OnFinish -= ReloadLevel;
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(_currentNameScene);
    }


}

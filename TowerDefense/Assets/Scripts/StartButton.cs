using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    private Animator _animator;
    private static readonly int HideButton = Animator.StringToHash("HideButton");
    private static readonly int ShowButton = Animator.StringToHash("ShowButton");


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void Start()
    {
        Show();
    }


    private void OnEnable()
    {
        FindObjectOfType<Wave>().GetComponent<Wave>().OnWaveEnd += Show;
    }

    private void OnDisable()
    {
        FindObjectOfType<Wave>().GetComponent<Wave>().OnWaveEnd -= Show;
    }


    public void Hide()
    {
        _animator.SetTrigger(HideButton);
    }


    public void Show()
    {
        _animator.SetTrigger(ShowButton);
    }
    
    
}

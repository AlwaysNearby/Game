using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Text _tapToPlay;
    [SerializeField] private Player _prebaf;

    private Input _input;

    private void Awake()
    {
        Instantiate(_prebaf);
        _input = new Input();
    }


    private void Start()
    {
        _input.Player.ClickDown.performed += context =>
        {
            _tapToPlay.gameObject.SetActive(false);
        };
    }

    private void OnEnable()
    {
        _input.Enable();
    }


    private void OnDisable()
    {
        _input.Disable();
    }
    
    
}

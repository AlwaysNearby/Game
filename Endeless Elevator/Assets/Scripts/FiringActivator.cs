using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiringActivator : MonoBehaviour
{

    public bool IsPressed => _isPressed;
    
    private Button _trigger;
    private bool _isPressed;

    private void Awake()
    {
        _trigger = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _trigger.onClick.AddListener(Activate);
    }

    private void OnDisable()
    {
        _trigger.onClick.RemoveListener(Activate);
    }

    private void Activate()
    {
        _isPressed = !_isPressed;
    }
    
}

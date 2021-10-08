using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatorModeAttack : MonoBehaviour
{
    private Button _activationButton;
    private bool _isActive = false;

    public bool IsActive => _isActive;

    private void Awake()
    {
        _activationButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _activationButton.onClick.AddListener(�hangeMode); 
    }

    private void OnDisable()
    {
        _activationButton.onClick.RemoveListener(�hangeMode);
    }

    private void �hangeMode()
    {
        _isActive = !_isActive;
    }
}

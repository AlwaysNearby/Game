using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class ActivatorModeAttack : MonoBehaviour
{
    private Input _input;

    private Button _activationButton;
    private bool _isActive = false;

    public bool IsActive => _isActive;

    private void Awake()
    {
        _activationButton = GetComponent<Button>();
        _input = GetComponentInParent<Input>();
    }

    private void OnEnable()
    {
        _activationButton.onClick.AddListener(ChangeMode);
        _input.OnEnable += Enable;
        _input.OnDisable += Disable;
    }

    private void OnDisable()
    {
        _activationButton.onClick.RemoveListener(ChangeMode);
        _input.OnEnable -= Enable;
        _input.OnDisable -= Disable;
    }

    private void ChangeMode()
    {
        _isActive = !_isActive;

        _activationButton.GetComponent<Image>().color = _isActive ? Color.red : Color.white;
    }
    
    private void Disable()
    {
        _activationButton.enabled = false;
    }

    private void Enable()
    {
        _activationButton.enabled = true;
    }
}

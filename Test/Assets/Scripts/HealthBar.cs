using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health _health;
    [SerializeField] private Image _viewBar;
    

    private void OnEnable()
    {
        _health.OnHit += PutTheCurrent;
    }

    private void OnDisable()
    {
        _health.OnHit -= PutTheCurrent;
    }

    private void PutTheCurrent(float currentHealth, float maxHealth)
    {
        _viewBar.fillAmount = currentHealth / maxHealth;
    }
    
}

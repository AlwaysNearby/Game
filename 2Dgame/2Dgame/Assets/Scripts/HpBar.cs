using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Text _health;
    [SerializeField] private float _maxHp;
    private string format = "{0}%";




    public void UpdateHpBar(float currentHealth)
    {
        _health.text = string.Format(format, (int)(currentHealth/_maxHp * 100));
    }
   
    
}

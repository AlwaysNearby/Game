using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamagable
{

    public UnityEvent OnDeath;

    public UnityEvent damageTakingEffect;

    public UpdateHpBar change;


    [SerializeField] private float _health;

    public void DecreaseHealth(float damage)
    {
        _health -= damage;
        change.Invoke(_health);
        damageTakingEffect.Invoke();
        if(_health <= 0)
        {
            OnDeath.Invoke();
        }
        
    }




    public float GetHp()
    {
        return _health;
    }
}

[System.Serializable]
public class UpdateHpBar : UnityEvent<float> { }


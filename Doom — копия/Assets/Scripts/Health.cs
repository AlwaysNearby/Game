using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDecrease
{

    [SerializeField] private float _health;
    private UnityEvent _OnDeath;


    private void Start()
    {
        _OnDeath = new UnityEvent();
        if (GetComponent<Enemy>() != null)
        {
            _OnDeath.AddListener(FindObjectOfType<Spawner>().GetComponent<Spawner>().ReductionOfMobs);
        }
        else if (GetComponent<MainLine>() != null)
        {
            print("");
        }
    }



    public void DecreaseHealth(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
             Destroy(this.gameObject);
             _OnDeath.RemoveAllListeners();
        }
    }



    private void OnDisable()
    {
        _OnDeath.Invoke();
    }
}

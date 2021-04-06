using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage;


    private List<string> _damageRegister = new List<string>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag != collision.tag)
        {
            var damagable = collision.GetComponent<IDamagable>();
            if (damagable != null) 
            {
                _damageRegister.Add(collision.name);
                StartCoroutine(DamageDealt(damagable, collision.name));
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        
        _damageRegister.Remove(collision.name);
    }

    public IEnumerator DamageDealt(IDamagable damagable, string damageRegisterName)
    {
        while(damagable != null && _damageRegister.Contains(damageRegisterName))
        {
            if (GetComponent<Bullet>() != null)
                Destroy(gameObject);
            damagable.DecreaseHealth(_damage);
            yield return new WaitForSeconds(0.2f);
        }

    }















}

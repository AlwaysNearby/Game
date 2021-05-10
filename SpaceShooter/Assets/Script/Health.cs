using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float _health;


    public GameObject[] damageEffect;
    public AudioClip damageSound;

    
    public void TakeDamage(float dmg)
    {
        _health -= dmg;

        if (damageEffect.Length != 0)
        {
            var effect = Instantiate(damageEffect[Random.Range(0, damageEffect.Length)], this.gameObject.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }

        if(damageSound != null)
        {
            SoundManager.instance.PlayMusic(damageSound);
        }

        if(_health <= 0)
        {
            if (this.gameObject.tag == "Meteor")
                GameManager.instance.UpdateUi();
            Destroy(this.gameObject);
        }
    }



    public float GetHealth()
    {
        return _health;
    }


    public void IncreaseHeal(float health)
    {
        _health += health;
        if(_health >= 100f)
        {
            _health = 100f;
        }
    }


}

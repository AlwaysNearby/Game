using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float _angleSpeed;
    private float _currentAngle;
    private Rigidbody2D rigidbody2D;


    public AudioClip[] _soundShoot;
    


    void Start()
    {
        _angleSpeed = 5f;
        _currentAngle = 0f;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _currentAngle = (_currentAngle + _angleSpeed * Input.GetAxis("Horizontal") * (-1)) % 360;
        transform.localRotation = Quaternion.Euler(0, 0, _currentAngle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var newBullet = GetComponent<Weapon>();
            newBullet.CreateBullet(transform, rigidbody2D.rotation * Mathf.Deg2Rad, false);
            SoundManager.instance.PlayMusic(_soundShoot[Random.Range(0, _soundShoot.Length)]);
        }    


    }


   




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Meteor" && GameObject.FindGameObjectWithTag("EffectShield") == null)
        {
            var dmgMeteor = collision.GetComponent<Meteor>();
            Destroy(collision.gameObject);
            var hp = this.GetComponent<Health>();
            hp.TakeDamage(dmgMeteor.dmg);
            GameManager.instance.UpdateHealth(hp.GetHealth());

            if(hp.GetHealth() <= 0)
            {
                GameManager.instance.UpdateGame();
            }
        }
        if(collision.gameObject.tag == "Shield")
        {
            if (GameObject.FindGameObjectWithTag("EffectShield") == null)
            {
                var newShield = collision.GetComponent<Bonus>();
                newShield.CreateBonus();
                Destroy(collision.gameObject);

            }
        }

        if(collision.gameObject.tag == "Heal")
        {
            var hp = this.GetComponent<Health>();
            hp.IncreaseHeal(Random.Range(0, 25));
            Destroy(collision.gameObject);
            GameManager.instance.UpdateHealth(hp.GetHealth());
        }
    }
}

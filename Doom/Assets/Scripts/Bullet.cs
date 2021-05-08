using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem explosionEffect;

    private float velocity;
    private float LifeTime = 10f;

    public float Velocity 
    {
        set 
        {
            velocity = value;
        }

        get 
        {
            return velocity;
        }
    }

    public void SetDiretion(Vector3 directon)
    {
        GetComponent<Rigidbody>().velocity = directon * velocity;



    }





    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (IsGunCollider(other))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }




    private bool IsGunCollider(Collider collider)
    {
        return collider.GetComponent<Gun>() == null;
    }


}

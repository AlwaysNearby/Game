using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{

    private float lifeTime;
    private float currentTime;



    private void Start()
    {
        lifeTime = Random.Range(5, 11);
        currentTime = lifeTime;
    }


    // Update is called once per frame
    void Update()
    {
        
        if(currentTime < 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            currentTime -= Time.deltaTime;
            GameManager.instance.UpdateShield(currentTime, lifeTime);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Meteor")
            Destroy(collision.gameObject);
    }



}

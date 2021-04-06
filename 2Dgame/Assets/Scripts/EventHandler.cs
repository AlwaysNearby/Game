using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{

    private GameController controller;
    [SerializeField] private ParticleSystem _deathEffect;
    



    void Awake()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }



    public void HandleDeathZombieEvent()
    {
        controller.IncreaseMobInWawe();
        StartDeathEffect(_deathEffect, this.transform);
        Destroy(this.gameObject);
    }



 


    public void HandleDeathPlayerOrMainTarget()
    {
        Destroy(this.gameObject);
    }


    private void StartDeathEffect(ParticleSystem effect, Transform where)
    {
        var particle = Instantiate(effect, where.position, Quaternion.identity);
        particle.Play();
    }

}

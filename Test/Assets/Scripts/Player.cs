using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] private float _speed;



    public void StopMovement()
    {
        _speed = 0f;
    }
    
    

    
    void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
    }
}

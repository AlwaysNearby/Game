using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public Transform targetPlayer;


    void Start()
    {
        transform.position = new Vector3(targetPlayer.position.x, transform.position.y, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        var NewPositioin = targetPlayer.position.x;
        transform.position = new Vector3(NewPositioin, transform.position.y, transform.position.z);


        
    }
}

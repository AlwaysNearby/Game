using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLine : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if(enemy != null)
        {
            Destroy(other.gameObject);
        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.StopMovement();
        }
    }
}

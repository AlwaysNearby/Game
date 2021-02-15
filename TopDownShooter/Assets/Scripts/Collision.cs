using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            var positionPlayer = transform.position;
            var positionWall = other.transform.position;
            var differensePos = positionWall - positionPlayer;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (-differensePos), Time.deltaTime * 3f * 0.5f);
            new WaitForSeconds(0.2f);
            print("1");
        }

    }
}

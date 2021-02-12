using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{

    public float MoveX()
    {
         return Input.GetAxis("Horizontal");

    }

    public float MoveY()
    {
        return Input.GetAxis("Vertical");
    }
}

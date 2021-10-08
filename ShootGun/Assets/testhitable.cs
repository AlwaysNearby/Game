using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testhitable : MonoBehaviour, IHitable
{
    public void Hit()
    {
        print("я умер");
    }
}

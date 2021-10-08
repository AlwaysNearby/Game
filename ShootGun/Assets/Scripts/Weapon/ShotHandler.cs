using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHandler : MonoBehaviour
{
    public void Handle(Collider hit)
    {
        IHitable hitable = hit.GetComponent<IHitable>();
        if(hitable != null)
        {
            hitable.Hit();
        }

    }
}

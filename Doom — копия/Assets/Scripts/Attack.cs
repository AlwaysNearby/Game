using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] private float dmg;


    private void OnTriggerEnter(Collider other)
    {
        var attackOption = this.GetComponent<IAttackOption>();
        if(attackOption != null)
        {
            attackOption.Charge(dmg, other);
        }

    }


}

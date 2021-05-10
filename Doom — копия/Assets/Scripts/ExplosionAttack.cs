using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAttack : MonoBehaviour, IAttackOption
{

    public LayerMask whatIsEnemy;

    private float _radiusOfDestruction;


    private void Start()
    {
        _radiusOfDestruction = 1.5F;
    }


    public void Charge(float dmg, Collider target)
    {
        var nearbyEnemies = Physics.OverlapSphere(target.transform.position, _radiusOfDestruction, whatIsEnemy);
        IDecrease decrease = null;

        if(nearbyEnemies.Length > 0)
        {
            for(var i = 0; i < nearbyEnemies.Length; i++)
            {
                decrease = nearbyEnemies[i].GetComponent<IDecrease>();
                decrease.DecreaseHealth(dmg / (Vector3.Distance(target.transform.position, nearbyEnemies[i].transform.position)));
            }
        }

    }

     
}

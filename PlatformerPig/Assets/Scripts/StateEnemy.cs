using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class StateEnemy : MonoBehaviour
{

    protected Enemy currentEnemy;

    

    public void SetNewEnemy(Enemy enemy)
    {
        currentEnemy = enemy;
    }

    
    public void Init()
    {

    }


    public abstract void Update();


    public abstract void Move();

    public abstract void Attack();

    public abstract void Jump();


}

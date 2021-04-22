using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Melee : StateEnemy
{
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Jump()
    {
        
    }

    public override void Move()
    {
        if(!currentEnemy.CanJump)
        {
            currentEnemy.SetAnimation("Run");
        }

        
        //
    }

    public override void Update()
    {
        if (!currentEnemy.CanAttack)
        {
            Move();
        }

        if (currentEnemy.CanJump)
        {
            Jump();
        }

        if (currentEnemy.CanAttack)
        {
            Attack();
        }

    }


   

}

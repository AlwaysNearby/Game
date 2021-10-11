using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (TryMove(transform.forward))
        {
            Move(transform.forward);
        }
    }

    
}

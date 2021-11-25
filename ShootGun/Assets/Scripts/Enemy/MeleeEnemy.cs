using System;
using AnimationEvent;
using DefaultNamespace.Animator.Parameters;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(MeleeWeapon))]
    public class MeleeEnemy : BaseEnemy
    {
        private MeleeWeapon _melee;

        protected override void Awake()
        {
            base.Awake();
            _melee = GetComponent<MeleeWeapon>();
        }
        

        private void Update()
        {
            if (TryMove(transform.forward))
            {
                MoveAt(transform.forward);
                
                AnimatorController.SetBool(ParameterEnemy.Walk, true);
            }
            else
            {
                if (_melee.TryAttack())
                {
                    AnimatorController.SetTrigger(ParameterEnemy.Attack);
                }
                
                AnimatorController.SetBool(ParameterEnemy.Walk, false);
            }
            
        }
    }
}
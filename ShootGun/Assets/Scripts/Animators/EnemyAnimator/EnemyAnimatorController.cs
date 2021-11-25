using System;
using DefaultNamespace.Animator.Parameters;
using UnityEngine;

namespace Animators.EnemyAnimator
{
    public class EnemyAnimatorController : AnimatorController
    {
        private void Awake()
        {
            InitParameters<ParameterEnemy>();
        }
    }
}

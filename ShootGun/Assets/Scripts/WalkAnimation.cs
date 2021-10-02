
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WalkAnimation : AnimatorBase
    {
        public WalkAnimation(Animator animator) : base(animator)
        {
            var parametrs = new Dictionary<Parametr, int>
            {
                {Parametr.IsObstacle, Animator.StringToHash("IsObstacle")},
                {Parametr.Walk, Animator.StringToHash("walk") },
            };

            SetParametrs(parametrs);
        }


        protected override void SetParametrs(Dictionary<Parametr, int> parametrs)
        {
            base.SetParametrs(parametrs);
        }

    }
}

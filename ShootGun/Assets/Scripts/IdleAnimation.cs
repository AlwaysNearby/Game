using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class IdleAnimation : AnimatorBase
    {
        public IdleAnimation(Animator animator) : base(animator)
        {
            var parametrs = new Dictionary<Parametr, int>
            {
                {Parametr.Idle, Animator.StringToHash("idle") },
            };

            SetParametrs(parametrs);
        }

        protected override void SetParametrs(Dictionary<Parametr, int> parametrs)
        {
            base.SetParametrs(parametrs);
        }
    }
}

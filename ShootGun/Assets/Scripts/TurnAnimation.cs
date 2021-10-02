using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

namespace Assets.Scripts
{
    public enum TurnType
    {
        LTurn = 0,
        RTurn = 1,
    }

    public class TurnAnimation : AnimatorBase
    {
        private Dictionary<TurnType, AnimationClip> _turnСlips;

        public TurnAnimation(Animator animator) : base(animator)
        {
            _turnСlips = new Dictionary<TurnType, AnimationClip>()
            {
                {TurnType.LTurn, animator.FindAnimation(nameof(TurnType.LTurn))},
                {TurnType.RTurn, animator.FindAnimation(nameof(TurnType.RTurn))},
            };


            var parametrs = new Dictionary<Parametr, int>
            {
                {Parametr.Turn, Animator.StringToHash("turn")},
                {Parametr.Direction, Animator.StringToHash("direction")},

            };

            SetParametrs(parametrs);
        }

        public float GetAnimationTime(TurnType turn)
        {
            return _turnСlips[turn].length;
        }
        protected override void SetParametrs(Dictionary<Parametr, int> parametrs)
        {
            base.SetParametrs(parametrs);
        }
    }
}

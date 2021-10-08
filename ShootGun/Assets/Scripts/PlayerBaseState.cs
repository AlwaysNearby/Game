using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{ 
    public abstract class PlayerBaseState
    {
        protected readonly ISwitcherState Switcher;
        protected readonly AnimatorController AnimatorController;
        protected readonly Touch Input;
        public PlayerBaseState(ISwitcherState switcher, AnimatorController animatorController, Touch input)
        {
            Switcher = switcher;
            AnimatorController = animatorController;
            Input = input;
        }
        
        public abstract void Update();

        public abstract void Start();
        
        public abstract void Stop();
    }
}
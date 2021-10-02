using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{ 
    public abstract class PlayerBaseState
    {
        protected readonly ISwitcherState Switcher;
        protected readonly TouchScroll Input;
        public PlayerBaseState(ISwitcherState switcher, TouchScroll input)
        {
            Switcher = switcher;
            Input = input;
        }
        
        public abstract void Update();

        public abstract void Enable();
        
        public abstract void Disable();
    }
}
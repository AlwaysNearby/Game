using UnityEngine;
namespace Player
{
    public abstract class BaseState
    {
        protected readonly Transform SelfTransform;
        protected readonly ISwitcherState Switcher;
        protected readonly Joystick Input;
        protected readonly Animator AnimationController;
        protected readonly FiringActivator Trigger;

        public BaseState(Transform self, FiringActivator trigger, ISwitcherState switcher, Joystick input)
        {
            SelfTransform = self;
            Trigger = trigger;
            Switcher = switcher;
            Input = input;
            AnimationController = self.GetComponentInChildren<Animator>();
        }
        
        public abstract void Update();

        public abstract void FixedUpdate();

        public abstract void Enable();

        public abstract void Disable();


    }
}
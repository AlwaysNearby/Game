using AnimatorSystem;
using DefaultNamespace;

namespace PlayerStates
{
    public abstract class PlayerBaseState
    {
        protected readonly ISwitcherPlayerState Context;
        protected readonly AnimatorController AnimationController;
        protected readonly PlayerInput Input;

        public PlayerBaseState(ISwitcherPlayerState context, AnimatorController animator, PlayerInput input)
        {
            Context = context;
            AnimationController = animator;
            Input = input;
        }

        public abstract void Start();
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void Stop();
    }
}
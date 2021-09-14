namespace Player
{
    public interface ISwitcherState
    {
        void SwitchState<T>() where T : BaseState;
    }
}
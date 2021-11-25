namespace PlayerStates
{
    public interface ISwitcherPlayerState
    {
        public void Switch<T>() where T : PlayerBaseState;
    }
}
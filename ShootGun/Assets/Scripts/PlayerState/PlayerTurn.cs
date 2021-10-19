using DefaultNamespace;
using DefaultNamespace.Animator.Parameters;
namespace PlayerState
{
    public class PlayerTurn : PlayerBaseState
    {
        private LookDirection _orientation;
        private Timer _turnTime;
        public PlayerTurn(ISwitcherState switcher, Input input, AnimatorController animator) : base(switcher, animator, input)
        {
            _orientation = LookDirection.Forward;
            _turnTime = new Timer(animator.GetClip("LTurn").length);
        }
        public override void Start()
        {
            AnimatorController.SetBool(ParameterPlayer.Turn, true);
            AnimatorController.SetInteger(ParameterPlayer.Direction, Input.ScrollDirection.x);
            _turnTime.Start();
        }

        public override void Update()
        {
            if (_turnTime.IsOver())
            {
                if(_orientation == LookDirection.Forward)
                {
                    Switcher.Switch<PlayerMover>();
                    _orientation = LookDirection.Side;
                }
                else
                {
                    Switcher.Switch<PlayerIdle>();
                    _orientation = LookDirection.Forward;
                }
            }
        }
        public override void Stop()
        {
            AnimatorController.SetBool(ParameterPlayer.Turn, false);
            AnimatorController.SetInteger(ParameterPlayer.Direction, 0);
        }
    }
}
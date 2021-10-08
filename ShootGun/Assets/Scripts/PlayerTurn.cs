using DefaultNamespace;

public class PlayerTurn : PlayerBaseState
{
        private LookDirection _orientation;
        private Timer _turnTime;
        public PlayerTurn(ISwitcherState switcher, Touch input, AnimatorController animator) : base(switcher, animator, input)
        {
            _orientation = LookDirection.Forward;
            _turnTime = new Timer(animator.GetAnimationTime("LTurn"));
        }
        public override void Start()
        {
            AnimatorController.SetBool(Parameter.Turn, true);
            AnimatorController.SetInteger(Parameter.Direction, Input.ScrollDirection.x);
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
            AnimatorController.SetBool(Parameter.Turn, false);
            AnimatorController.SetInteger(Parameter.Direction, 0);
        }
}
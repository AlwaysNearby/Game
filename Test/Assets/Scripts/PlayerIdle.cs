using UnityEngine;

public class PlayerIdle : BaseState
{
    private string _nameIdleAnimation;
    private Input _input;
    
    public PlayerIdle(ISwitcherState switcherState, Animator animator, Input input) : base(switcherState, animator)
    {
        _nameIdleAnimation = "Idle";
        _input = input;

        input.Player.ClickDown.performed += context =>
        {
            switcherState.SwitchState<PlayerMover>();
        };
    }

    public override void Start()
    {
        _input.Enable();
        animator.Play(_nameIdleAnimation);
    }

    public override void Stop()
    {
        _input.Disable();
        animator.StopPlayback();
    }

  
}

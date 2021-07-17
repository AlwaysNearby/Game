using UnityEngine;

public class PlayerShooter: BaseState
{
    private Input _input;
    private ShootingHandler _shootingHandler;
    private string _nameShootingAnimation;

    public PlayerShooter(ISwitcherState switcherState, Animator animator, Input input, ShootingHandler shootingHandler) : base(switcherState, animator)
    {
        _input = input;
        _shootingHandler = shootingHandler;
        _nameShootingAnimation = "Shooting";

        input.Player.ClickDown.performed += context =>
        {
            Shoot(_input.Player.ClickPosition.ReadValue<Vector2>());
        };
    }


    public override void Start()
    {
        animator.Play(_nameShootingAnimation);
        _shootingHandler.OnKillAllTargets += StopShoot;
        _input.Enable();
        
    }

    public override void Stop()
    {
        animator.StopPlayback();
        _shootingHandler.OnKillAllTargets -= StopShoot;
       _input.Disable();
    }


    private void StopShoot()
    {
        switcherState.SwitchState<PlayerMover>();
    }
    

    private void Shoot(Vector2 pointInScreen)
    {
       _shootingHandler.ShootAt(pointInScreen);
    }
    
    
   
    
}

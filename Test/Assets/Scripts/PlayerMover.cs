using System;
using UnityEngine;

public class PlayerMover : BaseState
{
    private float _speed;
    private MovePointHepler _movePointHepler;
    private Input _input;
    private string _nameWalkingAnimation;
   
    public PlayerMover(ISwitcherState switcherState, Animator animator, MovePointHepler movePointHepler, float speed) : base(switcherState, animator)
    {
        _speed = speed;
        _movePointHepler = movePointHepler;
        _nameWalkingAnimation = "Walking";

    }
    
    public override void Start()
    {
        _movePointHepler.OnEntryEndPoint += StopMove;
        animator.Play(_nameWalkingAnimation);
        StartMove();
        
    }

    public override void Stop()
    {
        _movePointHepler.OnEntryEndPoint -= StopMove;
        animator.StopPlayback();
    }


    private void StartMove()
    { 
        _movePointHepler.Move(_speed);
    }


    private void StopMove()
    {
        switcherState.SwitchState<PlayerShooter>();
    }
  
    

}

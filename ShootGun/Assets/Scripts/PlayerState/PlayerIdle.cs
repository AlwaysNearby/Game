using DefaultNamespace;
using DefaultNamespace.Animator.Parameters;
using UnityEngine;

namespace PlayerState
{
    public class PlayerIdle : PlayerBaseState
    {
        public PlayerIdle(ISwitcherState switcher, Input input, AnimatorController animator) : base(switcher, animator, input)
        {
        }

        public override void Start()
        {
            AnimatorController.SetBool(ParameterPlayer.Idle, true);
            Input.Enable();
        }


        public override void Update()
        {  
            if(Input.ScrollDirection != Vector2Int.zero)
            {
                Switcher.Switch<PlayerTurn>();     
            }
            else if(Input.IsActiveAttack)
            { 
                Switcher.Switch<PlayerShooter>();
            }
        }

        public override void Stop()
        {
            AnimatorController.SetBool(ParameterPlayer.Idle, false);
            Input.Disable();
        }
    }
}

using DefaultNamespace.Animator.Parameters;
public class PlayerAnimatorController : AnimatorController
{
    private void Awake()
    {
        InitParameters<ParameterPlayer>();
    }
}

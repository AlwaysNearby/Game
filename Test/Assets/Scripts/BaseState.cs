using UnityEngine;

public abstract class BaseState
{
    protected ISwitcherState switcherState;
    protected Animator animator;
    
    
    public BaseState(ISwitcherState switcherState, Animator animator)
    {
        this.switcherState = switcherState;
        this.animator = animator;
    }


    public abstract void Start();

    public abstract void Stop();

}

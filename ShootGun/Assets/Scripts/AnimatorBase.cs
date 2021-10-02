using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Parametr
{
    Walk,
    Idle,
    Turn,
    Direction,
    IsObstacle,
}

public abstract class AnimatorBase
{
    private Animator _animationContoller;
    private Dictionary<Parametr, int> _parametrValueID;
    public AnimatorBase(Animator animator)
    {
        _animationContoller = animator;
        _parametrValueID = new Dictionary<Parametr, int>();
    }

    public void SetTrigger(Parametr parametr)
    {
        _animationContoller.SetTrigger(_parametrValueID[parametr]);
    }

    public void SetInteger(Parametr parametr, int value)
    {
        _animationContoller.SetInteger(_parametrValueID[parametr], value);
    }


    public void SetBool(Parametr parametr, bool value)
    {
        _animationContoller.SetBool(_parametrValueID[parametr], value);
    }


    protected virtual void SetParametrs(Dictionary<Parametr, int> parametrs)
    {
        _parametrValueID = parametrs;
    }

}

using System;
using System.Collections.Generic;
using UnityEngine;

public enum Parameter
{
    Idle,
    Walk,
    Turn,
    IsObstacle, 
    Direction,
    Shoot,
}
[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animationContoller;

    private Dictionary<Parameter, int> _parametrValueID;

    private void Awake()
    {
        _parametrValueID = Hash(_animationContoller.parameters);
    }

    public void SetTrigger(Parameter parameter)
    {
        _animationContoller.SetTrigger(_parametrValueID[parameter]);
    }

    public void SetInteger(Parameter parameter, int value)
    {
        _animationContoller.SetInteger(_parametrValueID[parameter], value);
    }


    public void SetBool(Parameter parameter, bool value)
    {
        _animationContoller.SetBool(_parametrValueID[parameter], value);
    }

    public float GetAnimationTime(string name)
    {
        return _animationContoller.FindAnimation(name).length;
    }
    private Dictionary<Parameter, int> Hash(AnimatorControllerParameter[] parameters)
    {
        Dictionary<Parameter, int> hashValueId = new Dictionary<Parameter, int>();
        var valuearameters = Enum.GetValues(typeof(Parameter));

        foreach(var value in valuearameters)
        {
            var nameParametr = Array.Find(parameters, p => p.name == value.ToString());
            hashValueId.Add((Parameter)value, nameParametr.nameHash);
        }

        return hashValueId;
    }
}

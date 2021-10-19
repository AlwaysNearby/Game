using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animationContoller;

    private Dictionary<string, int> _parameterValueID;

    public void InitParameters<T>() where T : Enum
    {
        _parameterValueID = Hash<T>(_animationContoller.parameters);
    }

    public void SetTrigger<T>(T parameter) where T : Enum
    {
       _animationContoller.SetTrigger(_parameterValueID[parameter.ToString()]);
    }

    public void SetInteger<T>(T parameter, int value) where T : Enum
    {
        _animationContoller.SetInteger(_parameterValueID[parameter.ToString()], value);
    }


    public void SetBool<T>(T parameter, bool value) where T : Enum
    {
       _animationContoller.SetBool(_parameterValueID[parameter.ToString()], value);
    }

    public AnimationClip GetClip(string name) 
    {
        return _animationContoller.FindAnimation(name);
    }

    
    private Dictionary<string, int> Hash<T>(AnimatorControllerParameter[] parameters) where T : Enum
    {
        Dictionary<string, int> hashValueId = new Dictionary<string, int>();
        var valuearameters = Enum.GetValues(typeof(T));
        
        
        foreach(var value in valuearameters)
        {
            var nameParameter = Array.Find(parameters, p => p.name == value.ToString());
            hashValueId.Add(value.ToString(), nameParameter.nameHash);
        }

        return hashValueId;
    }
}

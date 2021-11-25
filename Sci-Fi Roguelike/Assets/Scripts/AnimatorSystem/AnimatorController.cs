using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnimatorSystem
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorController : MonoBehaviour
    {
        private Animator _animationController;
        private Dictionary<string, AnimatorControllerParameterType> _allParameters;

        private void Awake()
        {
            _animationController = GetComponent<Animator>();
        }

        private void Start()
        {
            _allParameters = Init(_animationController.parameters);
        }

        public void SetInt(string nameParameter, int value)
        {
            _animationController.SetInteger(nameParameter, value);
        }

        public void SetFloat(string nameParameter, float value)
        {
            _animationController.SetFloat(nameParameter, value);
        }

        public void SetBool(string nameParameter, bool value)
        {
            _animationController.SetBool(nameParameter, value);
        }

        public void SetTrigger(string nameParameter)
        {
            _animationController.SetTrigger(nameParameter);
        }
        
        private void TrySet(string nameParameter, AnimatorControllerParameterType type)
        {
            if (_allParameters.ContainsKey(nameParameter) == false)
            {
                throw new Exception($"Parameter with this name {nameParameter} does not exist");
            }

            if (_allParameters[nameParameter].Equals(type) == false)
            {
                throw new Exception($"Parameter with this name {nameParameter} is of type {_allParameters[nameParameter]}, not this {type}");
            }
        }

        private Dictionary<string, AnimatorControllerParameterType> Init(AnimatorControllerParameter[] parameters)
        {
            Dictionary<string, AnimatorControllerParameterType> allParametersTypes =
                new Dictionary<string, AnimatorControllerParameterType>();
            
            foreach (var parameter in parameters)
            {
                allParametersTypes.Add(parameter.name, parameter.type);
            }

            return allParametersTypes;
        }
    }
}
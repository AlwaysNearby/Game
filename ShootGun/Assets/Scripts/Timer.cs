using UnityEngine;
using System;
using UnityEditor.Timeline.Actions;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Timer
    {
        public event Action OnEnd;

        [SerializeField] private float _duration;
        
        private float _start;
        private bool _isStart;

        public Timer(float duration)
        {
            _duration = duration;
            _isStart = false;
        }
        
        public void Start()
        {
            _start = Time.time;
            _isStart = true;
        }


        public bool IsOver()
        {
            if (_isStart == false)
            {
                return true;
            }
            
            if (Time.time - _start > _duration)
            {
                OnEnd?.Invoke();
                _isStart = false;
                return true;
            }

            return false;
        }
    }
}
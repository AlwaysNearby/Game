using UnityEngine;
using System;

namespace DefaultNamespace
{
    public class Timer
    {
        public event Action OnEnd;

        private float _start;
        private float _duration;
        private bool _isStart;
        
        public Timer(float duration)
        {
            _duration = duration;
        }
        public void Start()
        {
            _start = Time.time;
            _isStart = true;
        }


        public bool IsOver()
        {
            if (_isStart == false)
                return true;

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
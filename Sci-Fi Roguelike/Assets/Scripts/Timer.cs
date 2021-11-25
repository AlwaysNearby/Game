using UnityEngine;

namespace DefaultNamespace
{
    public class Timer
    {
        private float _duration;
        private float _start;
        private bool _isStart;
        
        public Timer(float duration)
        {
            _duration = duration;
            _isStart = false;
        }

        public bool IsStart => _isStart;

        public void Start()
        {
            _isStart = true;
            _start = Time.time;
        }

        public void Stop()
        {
            _isStart = false;
        }

        public bool IsOver()
        {

            if (Time.time - _start >= _duration)
            {
                Stop();
                return true;
            }

            return false;
        }
    }
}
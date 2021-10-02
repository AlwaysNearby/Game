using UnityEngine;

namespace DefaultNamespace
{
    public class Timer
    {
        private float _start;
        private float _duration;
        
        public Timer(float duration)
        {
            _duration = duration;
        }


        public void Start()
        {
            _start = Time.time;
        }


        public bool IsOver()
        {
            if (Time.time - _start > _duration)
            {
                return true;
            }

            return false;
        }
    }
}
using DefaultNamespace;
using UnityEngine;

namespace CollisionDetected
{
    public abstract class TriggerHandler : MonoBehaviour
    {
        protected abstract void Handle(Collider collider);


        public bool Check<T>(Collider target) where T : ITarget
        {
            var goal = target.GetComponent<ITarget>();
            if (goal is T)
            {
                return true;
            }

            return false;
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            Handle(other);
        }
    }
}

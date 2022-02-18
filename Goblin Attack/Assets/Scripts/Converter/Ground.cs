using UnityEngine;

namespace Converter
{
    public class Ground : MonoBehaviour
    {
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }
        
        public bool Cast(Ray ray, float distance)
        {
            return _collider.Raycast(ray, out RaycastHit hit, distance);
        }
    }
}
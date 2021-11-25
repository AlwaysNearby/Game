using UnityEngine;

namespace DefaultNamespace
{
    public class ShootingHelper : MonoBehaviour
    {
        [SerializeField] private Collider2D _deathZone;

        public bool CheckDotHas(Vector2 point)
        {
            Bounds bounds = _deathZone.bounds;

            if (bounds.Contains(point))
            {
                return true;
            }

            return false;
        }
        
    }
}
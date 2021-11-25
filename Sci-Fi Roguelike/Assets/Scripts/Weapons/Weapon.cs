using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected List<LayerMask> _availableTargets;
        public abstract void ShotTowards(Vector2 position);
    }
}
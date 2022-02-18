using UnityEngine;

namespace ScriptableObjects.PlayerBundle
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Data/Player", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _minAgleRotaition, _maxAngleRotation, _angleLaunch;


        public float MinAngleRotation => _minAgleRotaition;
        public float MaxAngleRotation => _maxAngleRotation;
        public float AngleLaunch => _angleLaunch;

    }
}
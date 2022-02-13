using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrajectorySystem
{
    public class TrajectoryCalculator : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private int _countPoints;

        private const float _lengthCircle = 2 * Mathf.PI;

        public Vector3[] CalculationTrajectoryNodes(Vector3 targetPoint)
		{
            float temp = _lengthCircle / _countPoints;

            Vector3[] points = new Vector3[_countPoints];

            for(int i = 0; i < _countPoints; i++)
			{
                float step = temp * i;

                float x = targetPoint.x + _radius * Mathf.Cos(step);
                float z = targetPoint.z + _radius * Mathf.Sin(step);

                Vector3 position = new Vector3(x, 0, z);

                points[i] = position;
			}

            return points;
		}
	}
}

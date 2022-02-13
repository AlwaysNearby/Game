using UnityEngine;

namespace TrajectorySystem
{
    [RequireComponent(typeof(LineRenderer), typeof(TrajectoryCalculator))]
    public class Trajectory : MonoBehaviour
    {
        private LineRenderer _trajectoryRenderer;
        private TrajectoryCalculator _trajectoryCalculator;

        public void Init()
		{
            _trajectoryRenderer = GetComponent<LineRenderer>();
            _trajectoryCalculator = GetComponent<TrajectoryCalculator>();
		}
        
        public void Draw(Vector3 targetPoint)
		{
            Vector3[] points = _trajectoryCalculator.CalculationTrajectoryNodes(targetPoint);

            _trajectoryRenderer.positionCount = points.Length;

            _trajectoryRenderer.SetPositions(points);
		}


    }
}

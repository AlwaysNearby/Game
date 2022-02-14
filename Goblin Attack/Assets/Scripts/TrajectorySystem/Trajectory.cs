using System.Collections.Generic;
using UnityEngine;

namespace TrajectorySystem
{
    [RequireComponent(typeof(LineRenderer))]
    public class Trajectory : MonoBehaviour
    {
	    [SerializeField] private Transform _launchPoint;
	    [SerializeField] private Transform _hotizon;
	    [SerializeField] private int _maxCountPostions;
		
	    private const float Gravity = 9.81f;
	    
        private LineRenderer _trajectoryRenderer;
        private List<Vector3> _nodesTrajectory;
        
        public void Init()
		{
            _trajectoryRenderer = GetComponent<LineRenderer>();
            _nodesTrajectory = new List<Vector3>();
		}
        
        public void Draw(Vector3 speed, Vector3 targetPoint)
        {
	        for (int i = 0; i < _maxCountPostions; i++)
	        {
		        float time = i * 0.1f;

		        Vector3 position = _launchPoint.position + speed * time + Physics.gravity * (time * time * 0.5f);
		        
		        _nodesTrajectory.Add(position);

		        if (position.y < targetPoint.y)
		        {
			        break;
		        }
	        }
	        
	        _trajectoryRenderer.positionCount = _nodesTrajectory.Count;
	        _trajectoryRenderer.SetPositions(_nodesTrajectory.ToArray());
	        
	        _nodesTrajectory.Clear();
        }

        public Vector3 СalculateDirectionLaunch(float angleLaunchInDegrees,  Vector3 targetPoint)
        {
	        Vector3 direction = targetPoint - _launchPoint.position;

	        float lengthPath = direction.magnitude;

	        float angleDeflection = Vector3.Angle(_hotizon.forward, direction) * Mathf.Deg2Rad;

	        float angleLaunchInRadians = angleLaunchInDegrees * Mathf.Deg2Rad;

	        float correctAngle = angleDeflection + angleLaunchInRadians;

	        float sqrSpeed = lengthPath / ((Mathf.Sin(2 * correctAngle)) / (Gravity * Mathf.Cos(angleDeflection)) +
	                                       2 * Mathf.Sin(angleDeflection) * (Mathf.Pow(Mathf.Sin(correctAngle), 2)) /
	                                       (Gravity * Mathf.Pow(Mathf.Cos(angleDeflection), 2)));

	        float speed = Mathf.Sqrt(sqrSpeed);

	        return _launchPoint.forward * speed;
        }

      
    }
}

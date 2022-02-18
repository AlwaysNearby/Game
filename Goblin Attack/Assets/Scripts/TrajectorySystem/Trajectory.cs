using System.Collections.Generic;
using UnityEngine;

namespace TrajectorySystem
{
    [RequireComponent(typeof(LineRenderer))]
    public class Trajectory : MonoBehaviour
    {
	    [SerializeField] private Transform _launchPoint;
	    [SerializeField] private int _maxCountPostions;

	    private const float Gravity = 9.81f;
	    
        private LineRenderer _trajectoryRenderer;
        private List<Vector3> _nodesTrajectory;

        private void Awake()
        {
	        _trajectoryRenderer = GetComponent<LineRenderer>();
	        _nodesTrajectory = new List<Vector3>();
        }

        private void OnValidate()
        {
	        if (_maxCountPostions < 100)
	        {
		        _maxCountPostions = 100;
	        }

	        if (_maxCountPostions > 300)
	        {
		        _maxCountPostions = 300;
	        }
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

        public void Clear()
        {
	        _trajectoryRenderer.positionCount = 0;
        }
        
        public Vector3 СalculateDirectionLaunch(float angleLaunchInDegrees,  Vector3 targetPoint)
        {
	        Vector3 direction = targetPoint - _launchPoint.position;

	        float lengthPath = direction.magnitude;

	        float angleDeflection = Vector3.Angle(_launchPoint.forward, direction) * Mathf.Deg2Rad;

	        float angleLaunchInRadians = angleLaunchInDegrees * Mathf.Deg2Rad;

	        float correctAngle = angleDeflection + angleLaunchInRadians;

	        float sqrSpeed = lengthPath / ((Mathf.Sin(2 * correctAngle)) / (Gravity * Mathf.Cos(angleDeflection)) +
	                                       2 * Mathf.Sin(angleDeflection) * (Mathf.Pow(Mathf.Sin(correctAngle), 2)) /
	                                       (Gravity * Mathf.Pow(Mathf.Cos(angleDeflection), 2)));

	        direction /= lengthPath;
	        
	        float speed = Mathf.Sqrt(sqrSpeed);
	        
	        return new Vector3(speed * Mathf.Cos(-angleLaunchInRadians) * direction.x,
		        speed * Mathf.Sin(angleLaunchInRadians), speed * Mathf.Cos(-angleLaunchInRadians) * direction.z);
        }

      
    }
}

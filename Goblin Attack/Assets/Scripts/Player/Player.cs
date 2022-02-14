using Converter;
using Factories;
using Pool;
using TrajectorySystem;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(PixelCoordinateConverter), typeof(Gun))]
	public class Player : MonoBehaviour
	{
		[SerializeField] private Trajectory _trajectory;
		[SerializeField] private BulletPool _bulletPool;

		private PixelCoordinateConverter _pixelCoordinateConverter;
		private Gun _cannon;

		private void Awake()
		{
			_pixelCoordinateConverter = GetComponent<PixelCoordinateConverter>();
			_cannon = GetComponent<Gun>();
		}

		void Start()
		{
			_pixelCoordinateConverter.Init(new Plane(Vector3.up, Vector3.zero));
			_trajectory.Init();
			_bulletPool.Init();
			_cannon.Init(_bulletPool, _trajectory);
		}
		
		void Update()
		{
			Vector3 pointOnGround = _pixelCoordinateConverter.ProjectToGround(Input.mousePosition);
			
			_cannon.LookAt(pointOnGround);
			
			_cannon.ShowTrajectoryBullet(pointOnGround);
			
			if(Input.GetMouseButtonDown(0))
			{ 
				_cannon.LaunchTo(pointOnGround);
			}
		}
	}
}

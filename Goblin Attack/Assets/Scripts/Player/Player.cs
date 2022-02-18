using Converter;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(PixelCoordinateConverter), typeof(Gun))]
	public class Player : MonoBehaviour
	{
		private PixelCoordinateConverter _pixelCoordinateConverter;
		private Gun _cannon;

		private void Awake()
		{
			_pixelCoordinateConverter = GetComponent<PixelCoordinateConverter>();
			_cannon = GetComponent<Gun>();
		}
		
		void Update()
		{
			bool isProjectGround = _pixelCoordinateConverter.ProjectToGround(Input.mousePosition, out Vector3 position);

			_cannon.LookAt(position);

			if (isProjectGround)
			{
				_cannon.ShowTrajectoryBullet(position);

				if (Input.GetMouseButtonDown(0))
				{
					_cannon.LaunchTo(position);
				}
			}
			else
			{
				_cannon.HideTrajectoryBullet();
			}

		}
	}
}

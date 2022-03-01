using System;
using Converter;
using UnityEngine;
using Zenject;

namespace Character
{
	[RequireComponent(typeof(Gun))]
	public class Player : MonoBehaviour
	{
		private PixelCoordinateConverter _pixelCoordinateConverter;
		private Gun _cannon;

		[Inject]
		private void Construct(PixelCoordinateConverter pixelCoordinateConverter)
		{
			_pixelCoordinateConverter = pixelCoordinateConverter;
		}

		private void Start()
		{
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

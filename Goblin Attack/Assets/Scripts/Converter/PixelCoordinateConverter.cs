using System;
using UnityEngine;
using Zenject;

namespace Converter {
	public class PixelCoordinateConverter : MonoBehaviour
	{
		[SerializeField] private Camera _sourceRay;
		[SerializeField] private Ground _ground;
		
		private Plane _planeConvert;

		private void Start()
		{
			_planeConvert = new Plane(Vector3.up, Vector3.zero);
		}

		public bool ProjectToGround(Vector3 coordinatePixels, out Vector3 position)
		{
			float distanceToGround;

			Ray ray = _sourceRay.ScreenPointToRay(coordinatePixels);

			_planeConvert.Raycast(ray, out distanceToGround);
			
			position = ray.GetPoint(distanceToGround);
			
			if (_ground.Cast(ray, distanceToGround))
			{
				return true;
			}
			
			return false;
		}

	}
}

using UnityEngine;

namespace Converter {
	public class PixelCoordinateConverter : MonoBehaviour
	{
		private Plane _ground;
		private Camera _sourceRay;

		public void Init(Plane ground)
		{
			_sourceRay = Camera.main;
			_ground = ground;
		}


		public Vector3 ProjectToGround(Vector3 coordinatePixels)
		{
			float distanceToGround;

			Ray ray = _sourceRay.ScreenPointToRay(coordinatePixels);

			_ground.Raycast(ray, out distanceToGround);

			return ray.GetPoint(distanceToGround);
		}
	}
}

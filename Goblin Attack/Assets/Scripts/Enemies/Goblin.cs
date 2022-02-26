using UnityEngine;

namespace Enemies
{
	[RequireComponent(typeof(Rigidbody))]
	public abstract class Goblin : MonoBehaviour
	{
		[SerializeField] private float _speed;

		private Rigidbody _selfBody;

		private void Awake()
		{
			_selfBody = GetComponent<Rigidbody>();
		}

		public void Init(Vector3 placement)
		{
			transform.position = placement;
		}

		public void Move(Vector3 direction)
		{
			Vector3 currentPosition = _selfBody.position;
			Vector3 nextPosition = currentPosition + direction * _speed * Time.deltaTime;

			_selfBody.MovePosition(nextPosition);
		}

	}
}

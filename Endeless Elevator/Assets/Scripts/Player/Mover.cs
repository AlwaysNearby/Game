using UnityEngine;

namespace Player
{
    public class Mover
    {
        private readonly Rigidbody _self;
        private readonly float _speed;

        public Mover(Transform transform,  float speed)
        {
            _self = transform.GetComponent<Rigidbody>();
            _speed = speed;
        }


        public void MoveTo(Vector3 direction)
        {
            float deflectionAngle =
                Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);

            Quaternion rotation = Quaternion.AngleAxis(deflectionAngle, Vector3.up);

            Vector3 relativeDirection = (rotation * _self.transform.forward);
            
            Vector3 currentPosition = _self.position;
            Vector3 nextPosition = currentPosition + relativeDirection * _speed;

            Vector3 delta = Vector3.MoveTowards(currentPosition, nextPosition, Time.deltaTime * direction.magnitude *_speed);
            
            _self.MovePosition(delta);
        }
    }
}
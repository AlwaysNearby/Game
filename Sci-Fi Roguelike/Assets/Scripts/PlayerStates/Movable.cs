using AnimatorSystem;
using DefaultNamespace;
using UnityEngine;

namespace PlayerStates
{
    public abstract class Movable : PlayerBaseState
    {
        protected readonly Rigidbody2D Self;

        private float _speed;

        protected Movable(ISwitcherPlayerState context, AnimatorController animator, PlayerInput input,
            Rigidbody2D self, float speed) : base(context, animator, input)
        {
            Self = self;
            _speed = speed;
        }

        public void MoveAt(Vector2 direction)
        {
            Self.MovePosition(Self.position + direction * _speed * Time.deltaTime);
        }

        public void RotateAt(Vector2 direction)
        {
            var dot = Vector2.Dot(direction, Vector2.right);

            if (dot > 0)
            {
                Self.transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if (dot < 0)
            {
                Self.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }
}
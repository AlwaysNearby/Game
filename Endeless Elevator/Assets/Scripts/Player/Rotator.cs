using System;
using UnityEngine;

namespace Player
{
    public class Rotator
    {
        private readonly AreaToRotation _areaInput;
        private readonly float _angleSpeed;
        private readonly Rigidbody _self;

        public Rotator(Canvas inputArea, float angleSpeed, Transform self)
        {
            _angleSpeed = angleSpeed;
            _self = self.GetComponent<Rigidbody>();
            _areaInput = inputArea.GetComponentInChildren<AreaToRotation>();
        }



        public void Rotate()
        {
            Touch touch = FindTouchForRotate();
            
            Vector3 delta = new Vector3(touch.deltaPosition.x, 0f, touch.deltaPosition.y) * touch.deltaTime;

            Quaternion rotationY = Quaternion.AngleAxis(delta.x * _angleSpeed, Vector3.up);
            
            _self.MoveRotation(_self.rotation * rotationY);

        }

        private Touch FindTouchForRotate()
        {
            Touch resultInput = default;
            
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch input = Input.GetTouch(i);

                if (_areaInput.СheckHitArea(input.position))
                {
                    resultInput = input;
                    break;
                }
            }

            return resultInput;
        }
    }
}

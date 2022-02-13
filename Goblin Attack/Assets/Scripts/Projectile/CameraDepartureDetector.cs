using System;
using System.Collections.Generic;
using UnityEngine;

namespace Projectile
{
    public class CameraDepartureDetector : MonoBehaviour
    {
        private Action<Bullet> _flewedOutBorder;
        private Camera _mainCamera;
        private Vector2 _upperBound;
        private Vector2 _bottomBound;
        private Bullet _bullet;

        public void Init(Action<Bullet> flewedOutBorder, Bullet bullet)
        {
            _flewedOutBorder = flewedOutBorder;
            _bullet = bullet;
            _mainCamera = Camera.main;
            _upperBound = _mainCamera.pixelRect.size;
            _bottomBound = Vector2.zero;
        }

        private void Update()
        {
   
            Vector2 pointOnScreen = _mainCamera.WorldToScreenPoint(transform.position);

            if (pointOnScreen.x > _upperBound.x || pointOnScreen.y > _upperBound.x ||
                    pointOnScreen.x < _bottomBound.x || pointOnScreen.y < _bottomBound.y)
            {
                _flewedOutBorder?.Invoke(_bullet);
            }

        }

    
    }
}
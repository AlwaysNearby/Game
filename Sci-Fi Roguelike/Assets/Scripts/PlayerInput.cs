using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInput : MonoBehaviour
    {
        private Camera _mainCamera;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }
        public Vector2 Direction => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        public Vector2 MousePositionInWorldCoordinates => _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        public Vector2 MousePositionInScreenCoordinates => _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        public bool GetKeyDown(KeyCode code) => Input.GetKeyDown(code);
        public bool GetKeyUp(KeyCode code) => Input.GetKeyUp(code);
        public bool GetKey(KeyCode code) => Input.GetKey(code);


    }
}
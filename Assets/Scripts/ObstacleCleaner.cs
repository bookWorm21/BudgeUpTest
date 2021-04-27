using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BudgeUp
{
    public class ObstacleCleaner : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private float _forcePower;

        private Obstacle _currentObstacle;
        private Camera _main;
        private float _currentX;
        private float _currentY;

        private void Start()
        {
            _main = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out RaycastHit result, 100))
                {
                    if(result.collider.TryGetComponent(out Obstacle obstacle))
                    {
                        _currentObstacle = obstacle;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_currentObstacle != null)
                {
                    Rigidbody obstacleRigidbody = _currentObstacle.GetComponent<Rigidbody>();
                    obstacleRigidbody.AddForce(_forcePower * new Vector3(_currentX, 0.5f, _currentY)); 
                }

                _currentObstacle = null;
            }
            else
            {
                _currentX = _joystick.Horizontal;
                _currentY = _joystick.Vertical;
                if (_currentY < 0)
                {
                    _currentY = 0;
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BudgeUp
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private float _currentSpeed;

        public System.Action Died;

        private void Update()
        {
            transform.Translate(_currentSpeed * transform.forward * Time.deltaTime);    
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Obstacle _))
            {
                _currentSpeed = 0;
                Died?.Invoke();
            }
            else if(collision.gameObject.TryGetComponent(out Finish _))
            {
                Debug.Log("Win");
                _currentSpeed = 0;
            }
        }

        public void OnClickStartButton()
        {
            _currentSpeed = _speed;
        }
    }
}
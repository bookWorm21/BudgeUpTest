using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BudgeUp
{
    public class Obstacle : MonoBehaviour
    {
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        public void DisableCollider()
        {
            _collider.enabled = false;
        }
    }
}
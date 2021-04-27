using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BudgeUp
{
    public class GarbageTrigger : MonoBehaviour
    {
        public System.Action EnteredObstacle;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Obstacle obstacle))
            {
                obstacle.DisableCollider();
                EnteredObstacle?.Invoke();
            }
        }
    }
}
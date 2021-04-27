using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BudgeUp
{
    public class GarbageCounter : MonoBehaviour
    {
        [SerializeField] private GarbageTrigger[] _counters;
        [SerializeField] private int _pointPerObstacle;

        private int _points;

        public System.Action<int> ChangedPoints;

        private void OnEnable()
        {
            for (int i = 0; i < _counters.Length; i++)
            {
                _counters[i].EnteredObstacle += OnGarbageEnter;
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _counters.Length; i++)
            {
                _counters[i].EnteredObstacle -= OnGarbageEnter;
            }
        }

        private void OnGarbageEnter()
        {
            _points += _pointPerObstacle;
            ChangedPoints?.Invoke(_points);
        }
    }
}
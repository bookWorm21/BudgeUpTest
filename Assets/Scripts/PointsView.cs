using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.BudgeUp
{
    public class PointsView : MonoBehaviour
    {
        [SerializeField] private Text _pointsLabel;
        [SerializeField] private GarbageCounter _counter;

        private void OnEnable()
        {
            _counter.ChangedPoints += OnPointsChange;
        }

        private void Start()
        {
            OnPointsChange(0);
        }

        private void OnDisable()
        {
            _counter.ChangedPoints -= OnPointsChange;
        }

        private void OnPointsChange(int points)
        {
            _pointsLabel.text = points.ToString();
        }
    }
}
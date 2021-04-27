using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BudgeUp
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _obstaclePrefab;
        [SerializeField] private float _startZ;
        [SerializeField] private float _finishZ;

        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;

        [SerializeField] private float _positionY;

        [SerializeField] private float _minDeltaZBetweenObstacles;
        [SerializeField] private float _maxDeltaZBetweenObstacles;

        private void Start()
        {
            Vector3 currentSpawnPosition = Vector3.zero;
            Vector3 currentRotation;
            for (float currentZ = _startZ; currentZ < _finishZ; currentZ += Random.Range(_minDeltaZBetweenObstacles, _maxDeltaZBetweenObstacles))
            {
                float currentX = Random.Range(_minX, _maxX);
                currentSpawnPosition = new Vector3(currentX, _positionY, currentZ);
                currentRotation = new Vector3(0, Random.Range(0, 360), 0);
                Instantiate(_obstaclePrefab, currentSpawnPosition, Quaternion.Euler(currentRotation));
            }
        }
    }
}
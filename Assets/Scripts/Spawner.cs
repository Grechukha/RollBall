using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _firstSpawn;
    private float _nextSpawn;

    private void Start()
    {
        _nextSpawn = _firstSpawn;
    }

    private void Update()
    {
        if (Time.time > _nextSpawn)
        {
            float xPosition = transform.position.x;
            float yPosition = Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2) + transform.position.y;
            float zPosition = transform.position.z;

            Instantiate(_gameObject, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
            _nextSpawn = Time.time + Random.Range(_minDelay, _maxDelay);
        }
    }
}

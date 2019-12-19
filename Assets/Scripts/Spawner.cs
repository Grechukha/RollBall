using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject _gameObject;
    [SerializeField] protected float _minDelay;
    [SerializeField] protected float _maxDelay;
    [SerializeField] protected float _firstSpawn;
    protected float _nextSpawn;

    private void Start()
    {
        _nextSpawn = _firstSpawn;
    }

    private void Update()
    {
        Spawn();
    }

    protected virtual void Spawn()
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

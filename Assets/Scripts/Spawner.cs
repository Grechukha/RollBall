using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject _gameObject;
    [SerializeField] protected float _minDelay;
    [SerializeField] protected float _maxDelay;
    [SerializeField] protected float _firstSpawnTime;
    protected float _nextSpawnTime;
    protected Vector3 _nextSpawnPosition;

    private void Start()
    {
        _nextSpawnTime = _firstSpawnTime;
    }

    private void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnPosition = GetNextPosition();

            Instantiate(_gameObject, _nextSpawnPosition, Quaternion.identity);

            _nextSpawnTime = GetNextSpawnTime();
        }
    }
    
    protected virtual Vector3 GetNextPosition()
    {
        return new Vector3(transform.position.x, Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2)
            + transform.position.y, transform.position.z);
    }

    protected virtual float GetNextSpawnTime()
    {
        return Time.time + Random.Range(_minDelay, _maxDelay);
    }
}

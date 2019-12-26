using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private int _targetCount;

    private Vector3 _previousCoinPosition;
    private int _currentCoinNumber = 1;
    
    protected override Vector3 GetNextPosition()
    {
        return GetCoinPosition(_currentCoinNumber);
    }

    protected override float GetNextSpawnTime()
    {
        if (_currentCoinNumber > _targetCount - 1)
        {
            _currentCoinNumber = 1;
            return Time.time + _maxDelay;
        }
        else
        {
            _currentCoinNumber++;
            return Time.time + _minDelay;
        }
    }

    private Vector3 GetCoinPosition(int number)
    {
        Vector3 newCoinPosition = _previousCoinPosition;

        newCoinPosition.x = transform.position.x;

        if (number < 2)
        {
            newCoinPosition.z = transform.position.z;
            newCoinPosition.y = Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2) + transform.position.y;
        }
        else
        {
            newCoinPosition.y += Random.Range(-0.25f, 0.25f);
        }

        Mathf.Clamp(newCoinPosition.y, -transform.localScale.y + transform.position.y, transform.localScale.y + transform.position.y);

        _previousCoinPosition = newCoinPosition;

        return newCoinPosition;
    }
}

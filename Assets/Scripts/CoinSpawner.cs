using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private int _countOfCoins;
    private Vector3 _coinPosition;
    private int _currentCoinNumber = 1;

    protected override void Spawn()
    {
        if (Time.time > _nextSpawn)
        {
            _coinPosition.x = transform.position.x;

            if (_currentCoinNumber < 2)
            {
                _coinPosition.z = transform.position.z;
                _coinPosition.y = Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2) + transform.position.y;
            }
            else
            {
                _coinPosition.y += Random.Range(-0.25f, 0.25f);
            }


            Mathf.Clamp(_coinPosition.y, -transform.localScale.y + transform.position.y, transform.localScale.y + transform.position.y);
            Instantiate(_gameObject, _coinPosition, Quaternion.identity);
            _nextSpawn = Time.time + _minDelay;

            if (_currentCoinNumber > _countOfCoins - 1)
            {
                _currentCoinNumber = 0;
                _nextSpawn = Time.time + _maxDelay;
            }

            _currentCoinNumber++;
        }
    }
}

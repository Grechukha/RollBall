using UnityEngine;

public class PlatformsShifter : MonoBehaviour
{
    [SerializeField] private GroundPlatform[] _groundPlatforms;
    [SerializeField] private PlayerMovement _player;

    private void Update()
    {
        if (_player.transform.position.x > _groundPlatforms[1].transform.position.x)
        {
            ShiftPlatform();
        }
    }

    private void ShiftPlatform()
    {
        GroundPlatform firstPlatform = _groundPlatforms[0];

        firstPlatform.transform.position = GetNewPosition();

        for (int i = 0; i < _groundPlatforms.Length - 1; i++)
        {
            _groundPlatforms[i] = _groundPlatforms[i + 1];
        }

        _groundPlatforms[_groundPlatforms.Length - 1] = firstPlatform;
    }

    private Vector3 GetNewPosition()
    {
          return _groundPlatforms[_groundPlatforms.Length - 1].EndPoint.position - _groundPlatforms[0].StartPoint.localPosition;
    }
}


using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformShifter : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private Queue<GroundPlatform> _groundPlatforms = new Queue<GroundPlatform>();
    private float _nextShiftPositionX;

    private void Start()
    {
        var platforms = GetComponentsInChildren<GroundPlatform>();
        platforms.OrderBy(p => p.transform.position.x);

        foreach (var platform in platforms)
        {
            _groundPlatforms.Enqueue(platform);
        }
    }

    private void Update()
    {
        if (_player.transform.position.x > _nextShiftPositionX)
        {
            ShiftPlatform();
        }
    }

    private void ShiftPlatform()
    {
        var firstPlatform = _groundPlatforms.Dequeue();

        Vector3 newPosition = _groundPlatforms.ToArray()[_groundPlatforms.Count - 1].EndPoint.position - firstPlatform.StartPoint.localPosition;
        firstPlatform.transform.position = newPosition;

        _groundPlatforms.Enqueue(firstPlatform);

        _nextShiftPositionX = _groundPlatforms.ToArray()[1].transform.position.x;
    }
}

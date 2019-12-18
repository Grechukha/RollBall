using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformShifter : MonoBehaviour
{
    [SerializeField] private GroundPlatform[] _groundPlatforms;
    [SerializeField] private Player _player;

   private void Update()
    {
        if (_player.transform.position.x > _groundPlatforms[1].transform.position.x)
        {
            ShiftPlatform();
        }
    }

    private void ShiftPlatform()
    {
        ShiftPlatformsArray();
        ShiftPlatformPosition();
    }

    private void ShiftPlatformsArray()
    {
        GroundPlatform tempGroundPlatform = _groundPlatforms[0];

        for (int i = 0; i < _groundPlatforms.Length - 1; i++)
        {
            _groundPlatforms[i] = _groundPlatforms[i + 1];
        }

        _groundPlatforms[_groundPlatforms.Length - 1] = tempGroundPlatform;
    }

    private void ShiftPlatformPosition()
    {
        Vector3 newPosition = _groundPlatforms[_groundPlatforms.Length - 2].EndPoint.position
           - _groundPlatforms[_groundPlatforms.Length - 1].StartPoint.localPosition;

        _groundPlatforms[_groundPlatforms.Length - 1].transform.position = newPosition;
    }
}

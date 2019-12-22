using UnityEngine;

public class GroundPlatform : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    public Transform StartPoint => _startPoint;

    public Transform EndPoint => _endPoint;
}

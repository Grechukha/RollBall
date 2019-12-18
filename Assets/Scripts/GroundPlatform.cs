using UnityEngine;

public class GroundPlatform : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    public Transform StartPoint
    {
        get
        {
            return _startPoint;
        }
    }

    public Transform EndPoint
    {
        get
        {
            return _endPoint;
        }
    }
}

using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Camera _camera;
    private Vector3 _offset;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        transform.position = new Vector3(0, 2, -10);       
    }

    private void Update()
    {
        СalculateOffset();
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z) + _offset;
    }

    private void СalculateOffset()
    {
        _offset = new Vector3(_camera.orthographicSize * _camera.aspect * 0.66f, 0, 0);
    }
}

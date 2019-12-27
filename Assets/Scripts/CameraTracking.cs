using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraTracking : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private float _offsetRelativeCenterCameraX = -0.66f;

    private Camera _camera;
    
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z) + GetOffset();
    }

    private Vector3 GetOffset()
    {
       return new Vector3(_camera.orthographicSize * _camera.aspect * -_offsetRelativeCenterCameraX, 0, 0);
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _jumpForce = 25f;
    [SerializeField] private float _maxJumpTime = 0.35f;

    private float _currentJumpTime;
    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void FixedUpdate()
    {
        Roll();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsOnGround())
        {
            _currentJumpTime = _maxJumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && _currentJumpTime > 0)
        {
            _currentJumpTime -= Time.deltaTime;

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && !_groundChecker.IsOnGround())
        {
            _currentJumpTime = -1;
        }
    }

    private void Roll()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }
}

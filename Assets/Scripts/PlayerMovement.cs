using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _jumpForce = 25f;
    [SerializeField] private float _maxJumpTime = 0.35f;
    private float _storeMaxJumpTime;
    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();

        _storeMaxJumpTime = _maxJumpTime;
    }

    private void FixedUpdate()
    {
        Roll();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded)
        {
            _maxJumpTime = _storeMaxJumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && _maxJumpTime > 0)
        {
            _maxJumpTime -= Time.deltaTime;

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce); 
        }

        if (Input.GetKeyUp(KeyCode.Space) && !_groundChecker.IsGrounded)
        {
            _maxJumpTime = -1;
        }
    }

    private void Roll()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }
}

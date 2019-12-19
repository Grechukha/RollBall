using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speade;
    [SerializeField] private float _jumpForce = 0.25f;
    [SerializeField] private float _maxJumpTime = 0.25f;
    private float _storeMaxJumpTime;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _storeMaxJumpTime = _maxJumpTime;
    }

    private void Update()
    {
        Jump();
        Roll();
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _maxJumpTime = _storeMaxJumpTime;
        }

        if (_maxJumpTime > 0 && Input.GetKey(KeyCode.Mouse0))
        {
            _maxJumpTime -= Time.deltaTime;

            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && !_isGrounded)
        {
            _maxJumpTime = -1;
        }
    }

    private void Roll()
    {
        _rigidbody2D.velocity = new Vector2(_speade * Time.deltaTime, _rigidbody2D.velocity.y);
    }

    public void TakeDamage()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundPlatform>())
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundPlatform>())
        {
            _isGrounded = false;
        }
    }
}

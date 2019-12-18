using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speade;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Roll();
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce));
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

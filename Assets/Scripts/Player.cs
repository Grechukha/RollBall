using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public TMP_Text CountOfCoinsText;
    [SerializeField] private float _speade;
    [SerializeField] private float _jumpForce = 0.25f;
    [SerializeField] private float _maxJumpTime = 0.25f;
    private float _storeMaxJumpTime;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private int _countOfCoins;

    public int CountOfCoins
    {
        get
        {
            return _countOfCoins;
        }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _storeMaxJumpTime = _maxJumpTime;
    }

    private void FixedUpdate()
    {
        Roll();
        Jump();
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _maxJumpTime = _storeMaxJumpTime;
        }

        if (_maxJumpTime > 0 && Input.GetKey(KeyCode.Space))
        {
            _maxJumpTime -= Time.deltaTime;

            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyUp(KeyCode.Space) && !_isGrounded)
        {
            _maxJumpTime = -1;
        }
    }

    private void Roll()
    {
        _rigidbody2D.velocity = new Vector2(_speade, _rigidbody2D.velocity.y);
    }

    public void TakeDamage()
    {
        SceneManager.LoadScene("Menu");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Coin>())
        {
            _countOfCoins++;
            CountOfCoinsText.text = _countOfCoins.ToString();

            Destroy(collision.gameObject);
        }
    }
}

using UnityEngine;

public class GroundChecker : MonoBehaviour
{   
    public bool IsGrounded { get; private set; }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundPlatform>())
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundPlatform>())
        {
            IsGrounded = false;
        }
    }
}

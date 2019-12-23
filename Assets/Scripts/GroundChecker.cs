using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsGround;
    private float _radiusCircle = 0.8f;

    public bool IsGrounded
    {
        get
        {
            return Physics2D.OverlapCircle(transform.position, _radiusCircle, _whatIsGround);
        }
    }
}

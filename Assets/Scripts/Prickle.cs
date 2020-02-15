using UnityEngine;

public class Prickle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.TakeDamage();
        }
    }
}

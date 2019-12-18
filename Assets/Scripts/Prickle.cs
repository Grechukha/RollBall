using UnityEngine;

public class Prickle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            player.TakeDamage();
        }
    }
}

using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        var isRemovableObject = !collision.gameObject.GetComponent<GroundPlatform>() && !collision.gameObject.GetComponent<PlayerMovement>();

        if (isRemovableObject)
        {
            Destroy(collision.gameObject);
        }
    }
}

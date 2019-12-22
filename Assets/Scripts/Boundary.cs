using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        var isRemovableObject = (collision.gameObject.GetComponent<GroundPlatform>() == false) 
            && (collision.gameObject.GetComponent<PlayerMovement>() == false);

        if (isRemovableObject)
        {
            Destroy(collision.gameObject);
        }
    }
}

using UnityEngine;

public class ObjectsExistenceBoundary : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CanRemove(collision.gameObject))
        {
            Destroy(collision.gameObject);
        } 
    }

    private bool CanRemove(GameObject gameObject)
    {
        var isRemovableObject = true;

        if (gameObject.GetComponent<GroundPlatform>() == true)
        {
            isRemovableObject = false;
        }
        else if (gameObject.GetComponent<PlayerMovement>() == true)
        {
            isRemovableObject = false;
        }

        return isRemovableObject;
    }
}

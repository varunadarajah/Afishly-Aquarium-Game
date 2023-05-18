using UnityEngine;

public class PrefabCollider : MonoBehaviour
{
    public string objectNameToCheck = "RockCollider";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == objectNameToCheck)
        {
            // Collision occurred with the specified object
            Debug.Log("Prefab collider collided with " + objectNameToCheck);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == objectNameToCheck)
        {
            // Collision with the specified object ended
            Debug.Log("Prefab collider is no longer colliding with " + objectNameToCheck);
        }
    }
}

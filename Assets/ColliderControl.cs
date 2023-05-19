using UnityEngine;
using TMPro;

public class ColliderControl : MonoBehaviour
{
    private void Start()
    {
        DisableOwnColliderIfChildTextIsQuestionMarks();
    }

    private void DisableOwnColliderIfChildTextIsQuestionMarks()
    {
        TextMeshPro[] textObjects = GetComponentsInChildren<TextMeshPro>();

        foreach (TextMeshPro textObject in textObjects)
        {
            if (textObject.text == "???")
            {
                Collider ownCollider = GetComponent<Collider>();
                if (ownCollider != null)
                {
                    ownCollider.enabled = false;
                }

                // You can break out of the loop if you only want to disable the collider once.
                // Otherwise, you can remove the break statement to disable the collider on all parent objects with matching child text.
                break;
            }
        }
    }
}

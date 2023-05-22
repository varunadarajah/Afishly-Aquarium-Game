using UnityEngine;

public class HSBColorClicker : MonoBehaviour
{
    public GameObject targetObject; // The object whose color will be changed

    private SpriteRenderer targetSpriteRenderer; // The sprite renderer component of the target object

    private void Start()
    {
        // Get the sprite renderer component from the target object
        targetSpriteRenderer = targetObject.GetComponent<SpriteRenderer>();

        // Make sure the target object is assigned
        if (targetObject == null || targetSpriteRenderer == null)
        {
            Debug.LogError("Please assign the target object in the inspector.");
            enabled = false; // Disable the script if there are missing references
        }
    }

    private void OnMouseDown()
    {
        // Get the current color of the target object
        Color currentColor = targetSpriteRenderer.color;

        // Convert the color to a hex string
        string hexColor = ColorUtility.ToHtmlStringRGB(currentColor);

        // Print the hex color code
        Debug.Log("Hex Color Code: #" + hexColor);
    }
}

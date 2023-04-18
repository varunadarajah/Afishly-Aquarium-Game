using UnityEngine;

public class ExpandAxolotlScript : MonoBehaviour
{
    public float targetY; // The target Y position to animate the game object to
    public float targetScale; // The target scale to animate the game object to
    public float transformDuration = 1.0f; // The duration of the transformation animation

    private Vector3 originalPosition; // The original position of the game object
    private Vector3 originalScale; // The original scale of the game object
    private bool isTransforming = false; // Flag to determine if transformation is in progress
    private float transformStartTime; // The start time of the transformation

    void Start()
    {
        originalPosition = transform.position; // Store the original position of the game object
        originalScale = transform.localScale; // Store the original scale of the game object
    }

    void Update()
    {
        if (isTransforming)
        {
            // Calculate the current time elapsed since the transformation started
            float elapsedTime = Time.time - transformStartTime;

            // Calculate the progress of the transformation based on the elapsed time and duration
            float transformProgress = Mathf.Clamp01(elapsedTime / transformDuration);

            // Calculate the new Y position and scale of the game object based on the target values and transform progress
            Vector3 newPosition = new Vector3(originalPosition.x, Mathf.Lerp(originalPosition.y, targetY, transformProgress), originalPosition.z);
            Vector3 newScale = Vector3.Lerp(originalScale, new Vector3(originalScale.x, targetScale, originalScale.z), transformProgress);

            // Update the position and scale of the game object
            transform.position = newPosition;
            transform.localScale = newScale;

            // If the transformation is complete, stop transforming
            if (transformProgress >= 1.0f)
            {
                isTransforming = false;
            }
        }
    }

    void OnMouseDown()
    {
        // Start the transformation animation from the current position of the game object
        originalPosition = transform.position;
        originalScale = transform.localScale;
        isTransforming = true;
        transformStartTime = Time.time;
    }
}

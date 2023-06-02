using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRock : MonoBehaviour
{
    public string objectNameToCheck = "EditMode"; // The name of the object to check for

    public bool selected = false;

    public GameObject GreenOutline;
    public GameObject RedOutline;

    private new Renderer renderer; // Use 'new' keyword to hide the inherited member 'Component.renderer'

    private static GameObject prevClickedObject;
    

    public bool canMove = false;
    public bool isPickedUp = false;
    private Vector3 mousePositionOffset;

    public double midMaxHeight;
    public double sideMaxHeight;

    private Transform parentTransform; // reference to the parent transform
    private Collider2D parentCollider;

    public GameObject objectToFlash; // Reference to the object to flash
    public float flashInterval = 1.5f; // Interval between flashes in seconds

    private bool isFlashing = false;

    private Coroutine flashCoroutine; // store the reference to the flash coroutine

    //  button effect
    public AudioSource buttonSFX;

    private void Start()
    {
        parentTransform = transform.parent; // Get the parent transform
        parentCollider = transform.parent.GetComponent<Collider2D>();

        buttonSFX = GameObject.Find("ButtonSFX").GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool shouldFlash = CheckFlashingCondition();

        if (shouldFlash && !isFlashing)
        {
            // start flashing
            flashCoroutine = StartCoroutine(FlashCoroutine());
        }
        else if (!shouldFlash && isFlashing)
        {
            // stop flashing and disable the object
            if (flashCoroutine != null)
            {
                StopCoroutine(flashCoroutine);
            }
            isFlashing = false;
            objectToFlash.SetActive(false);
        }

        if (canMove && selected)
        {
            // check for collisions with an object named "RockCollider"
            bool isColliding = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(parentCollider.bounds.center, parentCollider.bounds.extents.x);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.name == "RockCollider")
                {
                    isColliding = true;
                    break;
                }
            }

            if (isColliding)
            {
                GreenOutline.SetActive(false);
                RedOutline.SetActive(true);
            }
            else
            {
                GreenOutline.SetActive(true);
                RedOutline.SetActive(false);
            }
        }
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.y - 0.001f);
    }

    private IEnumerator FlashCoroutine()
    {
    isFlashing = true;

    Color originalColor = objectToFlash.GetComponent<Renderer>().material.color;
    float targetAlpha = originalColor.a == 0f ? 1f : 0f;
    float currentAlpha = originalColor.a;
    float elapsedTime = 0f;

    while (elapsedTime < flashInterval)
    {
        elapsedTime += Time.deltaTime;

        // Calculate the new alpha value based on the elapsed time
        float t = elapsedTime / flashInterval;
        float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, t);

        // Update the alpha value of the object's color
        Color newColor = originalColor;
        newColor.a = newAlpha;
        objectToFlash.GetComponent<Renderer>().material.color = newColor;

        yield return null;
    }

    // Ensure the final alpha value is set correctly
    Color finalColor = originalColor;
    finalColor.a = targetAlpha;
    objectToFlash.GetComponent<Renderer>().material.color = finalColor;

    isFlashing = false;
}


    private bool CheckFlashingCondition()
    {
        return selected && !canMove;
    }

    private void OnEnable()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        // finds the object by name
        GameObject objectToCheck = GameObject.Find(objectNameToCheck);

        if (objectToCheck != null && objectToCheck.activeSelf)
        {
            buttonSFX.Play();

            if (selected && !canMove)
            {
                // If already selected, deselect the object
                selected = false;
                Color color = renderer.material.color;
                color.a = 1f;
                renderer.material.color = color;
            }
            else
            {
                // deselects the previously clicked object if it exists
                if (prevClickedObject != null && prevClickedObject.TryGetComponent(out PlantRock prevPlantRock))
                {
                    prevPlantRock.selected = false;
                    Renderer prevRenderer = prevClickedObject.GetComponent<Renderer>();
                    Color prevColor = prevRenderer.material.color;
                    prevColor.a = prevPlantRock.selected ? 0f : 1f;
                    prevRenderer.material.color = prevColor;
                }

                // sets the transparency of the current object to half
                selected = true;
                Color color = renderer.material.color;
                color.a = selected ? 0f : 1f;
                renderer.material.color = color;

                // sets the current object as the previously clicked object
                prevClickedObject = gameObject;
                objectToFlash.SetActive(true);

                if (canMove)
                {
                    isPickedUp = true;
                    mousePositionOffset = parentTransform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    objectToFlash.SetActive(false);
                    // disables colliders of all other prefabs
                    PlantRock[] plantRocks = FindObjectsOfType<PlantRock>();
                    foreach (PlantRock plantRock in plantRocks)
                    {
                        if (plantRock.gameObject != gameObject)
                        {
                            Collider2D[] colliders = plantRock.GetComponents<Collider2D>();
                            foreach (Collider2D collider in colliders)
                            {
                                collider.enabled = false;
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnMouseUp()
    {
        isPickedUp = false;
    }

    private void OnMouseDrag()
    {
        if (isPickedUp)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            parentTransform.position = new Vector3(mousePosition.x + mousePositionOffset.x, mousePosition.y + mousePositionOffset.y, parentTransform.position.z);
            mousePositionOffset = parentTransform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}

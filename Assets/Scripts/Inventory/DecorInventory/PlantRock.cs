using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRock : MonoBehaviour
{
    public string objectNameToCheck = "EditMode"; // The name of the object to check for

    public bool selected = false;

    // The renderer of the object
    private Renderer renderer;

    // The previously clicked object
    private static GameObject prevClickedObject;

    public bool canMove = false; 
    public bool isPickedUp = false;
    private Vector3 mousePositionOffset;

    private void OnEnable()
    {
        // Get the renderer component
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
    // Find the object by name
    GameObject objectToCheck = GameObject.Find(objectNameToCheck);

    if (objectToCheck != null && objectToCheck.activeSelf)
    {
        // Set the transparency of the previously clicked object back to normal
        if (prevClickedObject != null && prevClickedObject.GetComponent<PlantRock>() != null)
        {
            prevClickedObject.GetComponent<PlantRock>().selected = false;
            Renderer prevRenderer = prevClickedObject.GetComponent<Renderer>();
            Color prevColor = prevRenderer.material.color;
            prevColor.a = prevClickedObject.GetComponent<PlantRock>().selected ? 0.5f : 1f;
            prevRenderer.material.color = prevColor;
        }

        // Set the transparency of the current object to half
        selected = true;
        Color color = renderer.material.color;
        color.a = selected ? 0.5f : 1f;
        renderer.material.color = color;

        // Set the current object as the previously clicked object
        prevClickedObject = gameObject;
    }
    if (canMove == true && selected == true) 
        {
        isPickedUp = true;
        mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            transform.position = new Vector3(mousePosition.x + mousePositionOffset.x, mousePosition.y + mousePositionOffset.y, transform.position.z);
            mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update the mousePositionOffset
        }
    }

}
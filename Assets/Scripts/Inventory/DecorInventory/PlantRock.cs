 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRock : MonoBehaviour
{
    public string objectNameToCheck = "EditMode"; // The name of the object to check for

    public bool selected = false;

    public GameObject GreenOutline;
    public GameObject RedOutline;

    private Renderer renderer;

    private static GameObject prevClickedObject;

    public bool canMove = false;
    public bool isPickedUp = false;
    private Vector3 mousePositionOffset;

    public double midMaxHeight;
    public double sideMaxHeight;

    void Update ()
    {
        if (canMove == true && selected == true)
        {
            if (transform.position.x < -.32 ||  transform.position.x > .32) 
            {
                if(gameObject.name.Contains("Plant"))
                {
                    sideMaxHeight = -.5;
                } else if(gameObject.name.Contains("Rock"))
                {
                    sideMaxHeight = -.57;
                }
                if (transform.position.y < sideMaxHeight)
                {
                GreenOutline.SetActive(true);
                RedOutline.SetActive(false);
                } else {
                GreenOutline.SetActive(false);
                RedOutline.SetActive(true);
                }
            }

            if (transform.position.x > -.32 && transform.position.x < .32) 
            {
                if(gameObject.name.Contains("Plant"))
                {
                    midMaxHeight = -.63;
                } else if(gameObject.name.Contains("Rock"))
                {
                    midMaxHeight = -.7;
                }
                if (transform.position.y < midMaxHeight)
                {
                GreenOutline.SetActive(true);
                RedOutline.SetActive(false);
                } else {
                GreenOutline.SetActive(false);
                RedOutline.SetActive(true);
                }
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - 0.001f);
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
        // sets the transparency of the previously clicked object back to normal
        if (prevClickedObject != null && prevClickedObject.GetComponent<PlantRock>() != null)
        {
            prevClickedObject.GetComponent<PlantRock>().selected = false;
            Renderer prevRenderer = prevClickedObject.GetComponent<Renderer>();
            Color prevColor = prevRenderer.material.color;
            prevColor.a = prevClickedObject.GetComponent<PlantRock>().selected ? 0.5f : 1f;
            prevRenderer.material.color = prevColor;
        }

        // sets the transparency of the current object to half
        selected = true;
        Color color = renderer.material.color;
        color.a = selected ? 0.5f : 1f;
        renderer.material.color = color;

        // sets the current object as the previously clicked object
        prevClickedObject = gameObject;

        if (canMove == true)
        {
            isPickedUp = true;
            mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
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
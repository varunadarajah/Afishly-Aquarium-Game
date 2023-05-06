using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitEditMode : MonoBehaviour
{
    public GameObject editModeButtons;
    public GameObject homeButton;
    public GameObject EditModeScreen;
    public GameObject MoveDecorScreen;
    public GameObject parentObject;
    private PlantRock plantRock;

    public GameObject invalidText;
    private bool redOutlineActive = false;

    void Update() 
    {
        redOutlineActive = false; // Reset to false at the start of each frame

        Transform[] childObjects = parentObject.GetComponentsInChildren<Transform>();
        foreach (Transform childObject in childObjects)
        {
            PlantRock plantRock = childObject.GetComponent<PlantRock>();
            if (plantRock != null) 
            {
                if (plantRock.RedOutline.activeSelf) {
                    redOutlineActive = true;
                }
            }
        }  
    }

      private IEnumerator ToggleInvalidText()
    {
        invalidText.SetActive(true);
        yield return new WaitForSeconds(2f);
        invalidText.SetActive(false);
    }
    private void OnMouseDown()
    {
    if (redOutlineActive == true) {
        StartCoroutine(ToggleInvalidText());
    } else {
        invalidText.SetActive(false);
        editModeButtons.SetActive(false);
        homeButton.SetActive(true);

        //deselects all child objects
        foreach(Transform child in parentObject.transform)
        {
            PlantRock plantRock = child.GetComponent<PlantRock>();
            if(plantRock != null)
            {
                plantRock.selected = false;
                plantRock.canMove = false; 
                plantRock.GreenOutline.SetActive(false);
                plantRock.RedOutline.SetActive(false);
            }
        }

        // set all child objects of parentObject to full opacity
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            Renderer childRenderer = parentObject.transform.GetChild(i).GetComponent<Renderer>();
            if (childRenderer != null)
            {
                Color childColor = childRenderer.material.color;
                childColor.a = 1f;
                childRenderer.material.color = childColor;
            }
        }

        PlantRock[] plantRocks = FindObjectsOfType<PlantRock>();
        foreach (PlantRock plantRock in plantRocks)
        {
            if (plantRock.gameObject != gameObject)
            {
                Collider2D[] colliders = plantRock.GetComponents<Collider2D>();
                foreach (Collider2D collider in colliders)
                {
                    collider.enabled = true;
                }
            }
        }

        EditModeScreen.SetActive(true);
        MoveDecorScreen.SetActive(false);
    }
    }
}

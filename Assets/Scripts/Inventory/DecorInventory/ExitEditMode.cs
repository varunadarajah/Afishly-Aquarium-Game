using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEditMode : MonoBehaviour
{
    public GameObject editModeButtons;
    public GameObject homeButton;
    public GameObject parentObject;

    private void OnMouseDown()
    {
        editModeButtons.SetActive(false);
        homeButton.SetActive(true);

        //deselects all child objects
        foreach(Transform child in parentObject.transform)
        {
            PlantRock plantRock = child.GetComponent<PlantRock>();
            if(plantRock != null)
            {
                plantRock.selected = false;
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
    }
}

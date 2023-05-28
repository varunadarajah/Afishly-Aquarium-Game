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
    public GameObject disabledTab;
    public GameObject fishTab;


    public GameObject invalidText;
    public GameObject exitText;
    private bool redOutlineActive = false;

    private void Start()
    {
        // assign parentObject if not set
        if (parentObject == null)
        {
            parentObject = transform.parent.gameObject;
        }
    }

    void Update()
    {
        redOutlineActive = false; // reset to false at the start of each frame

        PlantRock[] plantRocks = parentObject.GetComponentsInChildren<PlantRock>(true);
        foreach (PlantRock plantRock in plantRocks)
        {
            if (plantRock.RedOutline.activeSelf)
            {
                redOutlineActive = true;
                break; // no need to continue checking if red outline is active on any child
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
        if (redOutlineActive)
        {
            StartCoroutine(ToggleInvalidText());
        }
        else
        {
            invalidText.SetActive(false);
            exitText.SetActive(false);
            editModeButtons.SetActive(false);
            homeButton.SetActive(true);
            fishTab.SetActive(true);
            disabledTab.SetActive(false);

            // deselect all child objects
            PlantRock[] plantRocks = parentObject.GetComponentsInChildren<PlantRock>(true);
            foreach (PlantRock plantRock in plantRocks)
            {
                plantRock.selected = false;
                plantRock.canMove = false;
                plantRock.GreenOutline.SetActive(false);
                plantRock.RedOutline.SetActive(false);
            }

            // set all child objects of parentObject to full opacity
            Renderer[] childRenderers = parentObject.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer childRenderer in childRenderers)
            {
                Color childColor = childRenderer.material.color;
                childColor.a = 1f;
                childRenderer.material.color = childColor;
            }

            // disable colliders of all child objects
            Collider2D[] childColliders = parentObject.GetComponentsInChildren<Collider2D>(true);
            foreach (Collider2D childCollider in childColliders)
            {
                childCollider.enabled = false;
            }

            EditModeScreen.SetActive(true);
            MoveDecorScreen.SetActive(false);
        }
    }
}

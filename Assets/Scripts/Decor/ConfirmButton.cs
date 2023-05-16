using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject EditModeButtons;
    public GameObject MoveDecorScreen;
    public GameObject InvalidText;

    private Collider2D confirmCollider;
    private bool greenOutlineActive = false;


    private void Start() {
        confirmCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        greenOutlineActive = false; // Reset to false at the start of each frame
        PlantRock[] plantRocks = parentObject.GetComponentsInChildren<PlantRock>(true);
        foreach (PlantRock plantRock in plantRocks)
        {
            if (plantRock.GreenOutline.activeSelf)
            {
                greenOutlineActive = true;
                break; // No need to continue checking if red outline is active on any child
            }
        }

        if (greenOutlineActive == true) {
            confirmCollider.enabled = true;
            SetObjectOpacity(gameObject, 1f);
        } else if (greenOutlineActive == false){
            confirmCollider.enabled = false;
            SetObjectOpacity(gameObject, 0.25f); 
        }     
    }
    

    private void OnMouseDown()
    {
        PlantRock[] plantRocks = parentObject.GetComponentsInChildren<PlantRock>(true);
            foreach (PlantRock plantRock in plantRocks)
            {
                plantRock.selected = false;
                plantRock.canMove = false;
                plantRock.GreenOutline.SetActive(false);
                plantRock.RedOutline.SetActive(false);
            }

       Renderer[] childRenderers = parentObject.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer childRenderer in childRenderers)
            {
                Color childColor = childRenderer.material.color;
                childColor.a = 1f;
                childRenderer.material.color = childColor;
            }

         PlantRock[] allPlantRocks = FindObjectsOfType<PlantRock>();
            foreach (PlantRock plantRock in allPlantRocks)
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
        greenOutlineActive = false;
        InvalidText.SetActive(false);
        EditModeButtons.SetActive(true);
        MoveDecorScreen.SetActive(false);
    }

    private void SetObjectOpacity(GameObject obj, float opacity)
    {
    Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
    foreach (Renderer renderer in renderers)
    {
        Color color = renderer.material.color;
        color.a = opacity;
        renderer.material.color = color;
    }
    }
}
